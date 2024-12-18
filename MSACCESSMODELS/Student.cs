using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.MODELSACCESS;

public partial class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? EMailAddress { get; set; }

    public string? StudentId { get; set; }

    public string? Level { get; set; }

    public string? Room { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? IdNumber { get; set; }

    public string? HomePhone { get; set; }

    public string? MobilePhone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? StateProvince { get; set; }

    public string? ZipPostalCode { get; set; }

    public string? CountryRegion { get; set; }

    public string? WebPage { get; set; }

    public string? Notes { get; set; }

    public string? Attachments { get; set; }

    public string? SpecialCircumstances { get; set; }

    public string? PhysicianName { get; set; }

    public string? PhysicianPhoneNumber { get; set; }

    public string? Allergies { get; set; }

    public string? Medications { get; set; }

    public string? InsuranceCarrier { get; set; }

    public string? InsuranceNumber { get; set; }
}
