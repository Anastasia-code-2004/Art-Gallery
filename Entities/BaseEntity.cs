﻿using SQLite;
namespace ArtGalleryApp.Entities;

public class BaseEntity
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int ID { get; set; }
}