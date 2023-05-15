using Microsoft.EntityFrameworkCore;
using doweb;
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

var builberConnectionDB = new ConfigurationBuilder();
builberConnectionDB.SetBasePath(Directory.GetCurrentDirectory());
builberConnectionDB.AddJsonFile("appsettings.json");
var config = builberConnectionDB.Build();
string connectionString = config.GetValue<string>("ConnectionStrings:DBConnection");
string host = config.GetValue<string>("ConnectionStrings:Host");
string port = config.GetValue<string>("ConnectionStrings:Port");
string connectionUrl = $"https://{host}:{port}";

ApplicationContexts db = new ApplicationContexts(connectionString);
List<Document> documents = db.Documents.ToList();

app.MapGet("/api/documents", () => documents);

app.MapGet("/api/documents/{id}", (int id) =>
{
    Document? document = documents.FirstOrDefault(d => d.Id == id);
    if (document == null) return Results.NotFound(new { message = "Document not found" });
    return Results.Json(document);
});

app.MapPost("/api/documents", (Document document) =>
{
    db.Documents.Add(document);
    db.SaveChanges();

    documents.Add(document);
    return Results.Json(document);
});

app.MapPut("/api/documents", (Document document) =>
{
    var editable = db.Documents.FirstOrDefault(d => d.Id == document.Id);
    var editableList = documents.FirstOrDefault(d => d.Id == document.Id);
    if (editable == null) return Results.NotFound(new { message = "Document not found" });
    editable.Number = document.Number;
    editableList.Number = document.Number;
    editable.Name = document.Name;
    editableList.Name = document.Name;
    editable.DateUpdate = DateTime.Now;
    editableList.DateUpdate = DateTime.Now;
    db.SaveChanges();

    return Results.Json(editable);
});

app.MapDelete("/api/documents/{id}", (int id) =>
{
    var deletion = db.Documents.FirstOrDefault(d => d.Id == id);
    var deletionList = documents.FirstOrDefault(d => d.Id == id);
    if (deletion == null) return Results.NotFound(new { message = "Document not found" });
    db.Documents.Remove(deletion);
    db.SaveChanges();

    documents.Remove(deletionList);
    return Results.Json(deletion);
});

app.Run(connectionUrl);