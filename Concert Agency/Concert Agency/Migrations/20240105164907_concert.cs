using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concert_Agency.Migrations
{
    /// <inheritdoc />
    public partial class concert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    PassportData = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    PassportData = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalParameter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeParameters = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalParameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VenueName = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Requirements = table.Column<string>(type: "text", nullable: false),
                    RiderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rider_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNum = table.Column<long>(type: "bigint", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderStatus = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertName = table.Column<string>(type: "text", nullable: false),
                    ConcertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VenueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concert_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationParameters = table.Column<string>(type: "text", nullable: false),
                    TechnicalParametersId = table.Column<Guid>(type: "uuid", nullable: false),
                    VenueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationalRequest_TechnicalParameter_TechnicalParameter~",
                        column: x => x.TechnicalParametersId,
                        principalTable: "TechnicalParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationalRequest_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiderRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RiderParameters = table.Column<string>(type: "text", nullable: false),
                    RiderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechnicalParametersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiderRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiderRequest_Rider_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Rider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiderRequest_TechnicalParameter_TechnicalParametersId",
                        column: x => x.TechnicalParametersId,
                        principalTable: "TechnicalParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcertArtist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcertArtist_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertArtist_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcertManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertDuties = table.Column<string>(type: "text", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcertManager_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertManager_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcertOrganization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Concert = table.Column<Guid>(type: "uuid", nullable: false),
                    FinalReceipt = table.Column<double>(type: "double precision", nullable: false),
                    VenueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcertOrganization_Concert_ID_Concert",
                        column: x => x.ID_Concert,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertOrganization_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    typePrice = table.Column<string>(type: "text", nullable: false),
                    buyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concert_VenueId",
                table: "Concert",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertArtist_ArtistId",
                table: "ConcertArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertArtist_ConcertId",
                table: "ConcertArtist",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertManager_ConcertId",
                table: "ConcertManager",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertManager_ManagerId",
                table: "ConcertManager",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertOrganization_ID_Concert",
                table: "ConcertOrganization",
                column: "ID_Concert",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConcertOrganization_VenueId",
                table: "ConcertOrganization",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ArtistId",
                table: "Order",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ManagerId",
                table: "Order",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderNum",
                table: "Order",
                column: "OrderNum",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalRequest_TechnicalParametersId",
                table: "OrganizationalRequest",
                column: "TechnicalParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalRequest_VenueId",
                table: "OrganizationalRequest",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Rider_ArtistId",
                table: "Rider",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_RiderRequest_RiderId",
                table: "RiderRequest",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_RiderRequest_TechnicalParametersId",
                table: "RiderRequest",
                column: "TechnicalParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ConcertId",
                table: "Ticket",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_VenueName_City_Country",
                table: "Venue",
                columns: new[] { "VenueName", "City", "Country" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertArtist");

            migrationBuilder.DropTable(
                name: "ConcertManager");

            migrationBuilder.DropTable(
                name: "ConcertOrganization");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrganizationalRequest");

            migrationBuilder.DropTable(
                name: "RiderRequest");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Rider");

            migrationBuilder.DropTable(
                name: "TechnicalParameter");

            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Venue");
        }
    }
}
