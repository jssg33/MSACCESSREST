using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Identity.Client;
using MySqlX.XDevAPI.Common;
using WEBAPI.MODELSACCESS;
using static Dapper.SqlMapper;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static Slapper.AutoMapper;
namespace WEBAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EntityFrameworkCore.Jet;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;

public static class StudentEndpoints
{
    public static async void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new ModelContext())
            {
                return context.Students.ToList();
            }

        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new ModelContext())
            {
                return context.Students.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Student input) =>
        {
            using (var context = new ModelContext())
            {
                Student[] somestudent = context.Students.Where(m => m.Id == id).ToArray();
                context.Students.Attach(somestudent[0]);
                //somestudents[0] = input;
                //Student result = new Student();
                //somestudent[0].Id = input.Id;
                somestudent[0].LastName = input.LastName;
                somestudent[0].FirstName = input.FirstName;
                somestudent[0].EMailAddress = input.EMailAddress;
                //context.Entry(somestudent[0]).State = EntityState.Modified;
                //result.LastName = "Smith";
                //result.FirstName = "Kyle";
                context.SaveChanges();
                //await context.SaveChangesAsync();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateStudent")
        .WithOpenApi();
            
        group.MapPost("/", (Student input) =>
        {
            using (var context = new ModelContext())
            {
                //Student somestudent = new Student();
                //context.Students.Attach(somestudent);
                //somestudent.FirstName = input.FirstName;
                //somestudent.LastName = input.LastName;
                //somestudent.EMailAddress = input.EMailAddress;
                //Random rand = new Random();
                //int randomIntInRange = rand.Next(0, 101);
                //somestudent.Id = randomIntInRange;
                context.Students.Add(input);
                context.Students.Attach(input);
                             
                //input.Id = randomIntInRange;
                context.Entry(input).State = context.Modified;
                context.SaveChanges();
                //await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
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

    /// STUDENT ATTENDANCE >
    /// 
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
        
        /*[HttpPost]
            async Task<ActionResult<Student>> PostStudent(Student input)
            {
                using (var context = new ModelContext())
                {
                context.Students.Add(input);
                await context.SaveChangesAsync();
                }
                return input;
                //return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }

            [EnableCors("Policy1")]
            [HttpPost]*/
    }
}
