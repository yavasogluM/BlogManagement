﻿// <auto-generated />
using System;
using BlogManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200403194824_AuthorCreate")]
    partial class AuthorCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogManagement.Data.Models.ApiVersionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("VersionDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VersionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApiVersionEntities");
                });

            modelBuilder.Entity("BlogManagement.Data.Models.ArticleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("ArticleEntities");
                });

            modelBuilder.Entity("BlogManagement.Data.Models.AuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthorEntities");
                });

            modelBuilder.Entity("BlogManagement.Data.Models.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("CommentEntities");
                });

            modelBuilder.Entity("BlogManagement.Data.Models.ArticleEntity", b =>
                {
                    b.HasOne("BlogManagement.Data.Models.AuthorEntity", "Author")
                        .WithMany("Article")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("BlogManagement.Data.Models.CommentEntity", b =>
                {
                    b.HasOne("BlogManagement.Data.Models.ArticleEntity", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId");
                });
#pragma warning restore 612, 618
        }
    }
}
