using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter: ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
