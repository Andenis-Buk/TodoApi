﻿using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data.TodoItems.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
    : base(options)
    {
    }

    public DbSet<TodoItemEntity> TodoItems { get; set; } = null!;
}
