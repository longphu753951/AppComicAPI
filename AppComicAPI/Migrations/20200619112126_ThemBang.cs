using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppComicAPI.Migrations
{
    public partial class ThemBang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(nullable: false),
                    MatKhau = table.Column<string>(nullable: false),
                    TenHienThi = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTheLoai = table.Column<string>(maxLength: 300, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truyens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruyen = table.Column<string>(maxLength: 200, nullable: false),
                    NgayDang = table.Column<DateTime>(nullable: false),
                    MaTaiKhoanDang = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<string>(maxLength: 300, nullable: false),
                    Like = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Truyens_TaiKhoans_MaTaiKhoanDang",
                        column: x => x.MaTaiKhoanDang,
                        principalTable: "TaiKhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuong = table.Column<string>(maxLength: 200, nullable: false),
                    NgayDang = table.Column<DateTime>(nullable: false),
                    MaTruyen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Truyens_MaTruyen",
                        column: x => x.MaTruyen,
                        principalTable: "Truyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheLoaiTruyens",
                columns: table => new
                {
                    MaTruyen = table.Column<int>(nullable: false),
                    MaTheLoai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoaiTruyens", x => new { x.MaTheLoai, x.MaTruyen });
                    table.ForeignKey(
                        name: "FK_TheLoaiTruyens_TheLoais_MaTheLoai",
                        column: x => x.MaTheLoai,
                        principalTable: "TheLoais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheLoaiTruyens_Truyens_MaTruyen",
                        column: x => x.MaTruyen,
                        principalTable: "Truyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TruyenYeuThichs",
                columns: table => new
                {
                    MaTruyen = table.Column<int>(nullable: false),
                    MaTaiKhoan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruyenYeuThichs", x => new { x.MaTaiKhoan, x.MaTruyen });
                    table.ForeignKey(
                        name: "FK_TruyenYeuThichs_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruyenYeuThichs_Truyens_MaTruyen",
                        column: x => x.MaTruyen,
                        principalTable: "Truyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChapter = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Chapters_MaChapter",
                        column: x => x.MaChapter,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_MaTruyen",
                table: "Chapters",
                column: "MaTruyen");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_MaChapter",
                table: "Pages",
                column: "MaChapter");

            migrationBuilder.CreateIndex(
                name: "IX_TheLoaiTruyens_MaTruyen",
                table: "TheLoaiTruyens",
                column: "MaTruyen");

            migrationBuilder.CreateIndex(
                name: "IX_Truyens_MaTaiKhoanDang",
                table: "Truyens",
                column: "MaTaiKhoanDang");

            migrationBuilder.CreateIndex(
                name: "IX_TruyenYeuThichs_MaTruyen",
                table: "TruyenYeuThichs",
                column: "MaTruyen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "TheLoaiTruyens");

            migrationBuilder.DropTable(
                name: "TruyenYeuThichs");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "TheLoais");

            migrationBuilder.DropTable(
                name: "Truyens");

            migrationBuilder.DropTable(
                name: "TaiKhoans");
        }
    }
}
