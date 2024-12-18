using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WEBAPI.MODELSACCESS;
using static Dapper.SqlMapper;
using static Slapper.AutoMapper;
namespace WEBAPI.Controllers;

public static class StudentEndpoints
{
    public static async void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", () =>
        {
            using (var context = new ModelContext())
            {
                return context.Students.ToList();
            }
            
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new ModelContext())
            {
                return context.Students.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Student input) =>
        {
            using (var context = new ModelContext())
            {
                //context.Students.Add(std);
                //Student[] somestudents = context.Students.Where(m => m.Id == id).ToArray();
                //context.Students.Attach(somestudents[0]);
                //somestudents[0] = input;
                //context.SaveChanges();
                Student result = new Student();
                result = input;
                context.SaveChanges();
                //return TypedResults.Created($"/api/Student/{input.Id}", input);
                //return id ? TypedResults.Ok() : TypedResults.NotFound();
            }
            

        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", async (Student input) =>
        {
            //Add Record
            using (var context = new ModelContext())
            {
                context.Students.Add(input);
                context.Students.Attach(input);
                await context.SaveChangesAsync();
                return TypedResults.Created($"/api/Store/{input.Id}", input);
            }
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            using (var context = new ModelContext())
            {
                //context.Students.Add(std);
                Student[] somestudents = context.Students.Where(m => m.Id == id).ToArray();
                context.Students.Attach(somestudents[0]);
                context.Students.Remove(somestudents[0]);
                context.SaveChanges();
                }
            
        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
	public static void MapStudentAttendanceEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/StudentAttendance").WithTags(nameof(StudentAttendance));

        group.MapGet("/", () =>
        {
            return new [] { new StudentAttendance() };
        })
        .WithName("GetAllStudentAttendances")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new StudentAttendance { ID = id };
        })
        .WithName("GetStudentAttendanceById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, StudentAttendance input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateStudentAttendance")
        .WithOpenApi();

        group.MapPost("/", (StudentAttendance model) =>
        {
            //return TypedResults.Created($"/api/StudentAttendances/{model.ID}", model);
        })
        .WithName("CreateStudentAttendance")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new StudentAttendance { ID = id });
        })
        .WithName("DeleteStudentAttendance")
        .WithOpenApi();
    }
}
