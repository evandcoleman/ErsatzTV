﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErsatzTV.Infrastructure.MySql.Migrations
{
    /// <inheritdoc />
    public partial class Reset_LocalLibraryFolders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // reset local library folders, and require scans

            migrationBuilder.Sql(
                @"UPDATE LibraryPath SET LastScan = '0001-01-01 00:00:00' WHERE Id IN
                (SELECT A.lpid FROM
                (SELECT LP.Id AS lpid FROM Library L INNER JOIN LibraryPath LP ON L.Id = LP.LibraryId INNER JOIN LocalMediaSource LMS ON LMS.Id = L.MediaSourceId)
                AS A)");

            migrationBuilder.Sql(
                @"UPDATE Library SET LastScan = '0001-01-01 00:00:00' WHERE MediaSourceId IN (SELECT Id FROM LocalMediaSource)");

            migrationBuilder.Sql(
                @"DELETE FROM LibraryFolder WHERE LibraryPathId IN (SELECT LP.Id FROM Library L INNER JOIN LibraryPath LP ON L.Id = LP.LibraryId INNER JOIN LocalMediaSource LMS ON LMS.Id = L.MediaSourceId)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
