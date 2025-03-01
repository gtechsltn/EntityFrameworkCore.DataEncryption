﻿using SoftFluent.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftFluent.EntityFrameworkCore.DataEncryption.Test.Context;

public sealed class AuthorEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Guid UniqueId { get; set; }

    [Required]
    [Encrypted]
    public string FirstName { get; set; }

    [Required]
    [Encrypted(StorageFormat.Binary)]
    [Column(TypeName = "BLOB")]
    public string LastName { get; set; }

    [Required]
    public int Age { get; set; }

    public IList<BookEntity> Books { get; set; }

    public AuthorEntity(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Books = new List<BookEntity>();
        UniqueId = Guid.NewGuid();
    }
}
