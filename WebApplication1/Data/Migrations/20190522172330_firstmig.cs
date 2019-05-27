using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "NameFamily",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<int>(nullable: false),
                    CTime = table.Column<DateTime>(nullable: false),
                    CourseName = table.Column<string>(nullable: false),
                    Explain = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    TeacherBio = table.Column<string>(nullable: true),
                    TeacherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Film",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Cast = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Explain = table.Column<string>(nullable: true),
                    FilmName = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TTime = table.Column<DateTime>(nullable: false),
                    Writer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Film", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_OtherServer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HttpDomain = table.Column<string>(maxLength: 255, nullable: false),
                    IP = table.Column<string>(maxLength: 150, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Path = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_OtherServer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Teater",
                columns: table => new
                {
                    TeaterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Cast = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Explain = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    TTime = table.Column<DateTime>(nullable: false),
                    TeaterName = table.Column<string>(nullable: false),
                    Writer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Teater", x => x.TeaterId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Images",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alt = table.Column<string>(nullable: true),
                    Filename = table.Column<string>(nullable: false),
                    ServerID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Images_Tbl_OtherServer_ServerID",
                        column: x => x.ServerID,
                        principalTable: "Tbl_OtherServer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false),
                    IDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    Price = table.Column<string>(maxLength: 15, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    TeaterId = table.Column<int>(nullable: false),
                    TransactionID = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Invoice_Tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Tbl_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Invoice_Tbl_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Tbl_Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Invoice_Tbl_Teater_TeaterId",
                        column: x => x.TeaterId,
                        principalTable: "Tbl_Teater",
                        principalColumn: "TeaterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Invoice_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Shopping",
                columns: table => new
                {
                    ShoppingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    Price = table.Column<string>(maxLength: 15, nullable: false),
                    SDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    TeaterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Shopping", x => x.ShoppingID);
                    table.ForeignKey(
                        name: "FK_Tbl_Shopping_Tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Tbl_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Shopping_Tbl_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Tbl_Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Shopping_Tbl_Teater_TeaterId",
                        column: x => x.TeaterId,
                        principalTable: "Tbl_Teater",
                        principalColumn: "TeaterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Shopping_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Gallery",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    FilmId = table.Column<int>(nullable: false),
                    NamePic = table.Column<string>(nullable: false),
                    TeaterId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ViewImageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Gallery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Gallery_Tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Tbl_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Gallery_Tbl_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Tbl_Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Gallery_Tbl_Teater_TeaterId",
                        column: x => x.TeaterId,
                        principalTable: "Tbl_Teater",
                        principalColumn: "TeaterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Gallery_Tbl_Images_ViewImageID",
                        column: x => x.ViewImageID,
                        principalTable: "Tbl_Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Gallery_CourseId",
                table: "Tbl_Gallery",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Gallery_FilmId",
                table: "Tbl_Gallery",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Gallery_TeaterId",
                table: "Tbl_Gallery",
                column: "TeaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Gallery_ViewImageID",
                table: "Tbl_Gallery",
                column: "ViewImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Images_ServerID",
                table: "Tbl_Images",
                column: "ServerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Invoice_CourseId",
                table: "Tbl_Invoice",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Invoice_FilmId",
                table: "Tbl_Invoice",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Invoice_TeaterId",
                table: "Tbl_Invoice",
                column: "TeaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Invoice_UserId",
                table: "Tbl_Invoice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shopping_CourseId",
                table: "Tbl_Shopping",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shopping_FilmId",
                table: "Tbl_Shopping",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shopping_TeaterId",
                table: "Tbl_Shopping",
                column: "TeaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shopping_UserId",
                table: "Tbl_Shopping",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tbl_Gallery");

            migrationBuilder.DropTable(
                name: "Tbl_Invoice");

            migrationBuilder.DropTable(
                name: "Tbl_Shopping");

            migrationBuilder.DropTable(
                name: "Tbl_Images");

            migrationBuilder.DropTable(
                name: "Tbl_Course");

            migrationBuilder.DropTable(
                name: "Tbl_Film");

            migrationBuilder.DropTable(
                name: "Tbl_Teater");

            migrationBuilder.DropTable(
                name: "Tbl_OtherServer");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "NameFamily",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
