using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBD3.Data.NBDMigrations
{
    /// <inheritdoc />
    public partial class ProjStaffPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BidStatus",
                table: "Bids",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BidStatusList",
                table: "Bids",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectPhotos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(type: "BLOB", nullable: true),
                    MimeType = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhotos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectPhotos_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectThumbnails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(type: "BLOB", nullable: true),
                    MimeType = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectThumbnails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectThumbnails_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffPhotos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(type: "BLOB", nullable: true),
                    MimeType = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    StaffID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPhotos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StaffPhotos_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffThumbnails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(type: "BLOB", nullable: true),
                    MimeType = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    StaffID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffThumbnails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StaffThumbnails_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhotos_ProjectID",
                table: "ProjectPhotos",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectThumbnails_ProjectID",
                table: "ProjectThumbnails",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffPhotos_StaffID",
                table: "StaffPhotos",
                column: "StaffID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffThumbnails_StaffID",
                table: "StaffThumbnails",
                column: "StaffID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPhotos");

            migrationBuilder.DropTable(
                name: "ProjectThumbnails");

            migrationBuilder.DropTable(
                name: "StaffPhotos");

            migrationBuilder.DropTable(
                name: "StaffThumbnails");

            migrationBuilder.DropColumn(
                name: "BidStatus",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "BidStatusList",
                table: "Bids");
        }
    }
}
