using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO.FeedLabels;
using DietPreparation.Services.FeedLabels.Interfaces;
using System.Text;

namespace DietPreparation.Services.FeedLabels;

internal class FeedLabelBuilder : IFeedLabelBuilder
{
	public string GenerateZpl(PrintFeedLabelDto dto, int bagNumber)
	{
		return new StringBuilder()
			.AppendLine(" ^XA")
			.AppendLine(" ^CF0,25 ")
			.AppendLine(" ^FO740,020^A0R,25^FDLot No: ^FS")
			.AppendLine(" ^FO740,670^A0R,25^FDExpiration Date: ^FS")
			.AppendLine($" ^FO625,20^A0R,105,84^FD{GetLotNumber(dto, bagNumber)}^FS")
			.AppendLine($" ^FO740,900^A0R,40^FD{GetDateString(dto.ExpirationDate)}^FS")
			.AppendLine(" ^FO600,020^A0R,25^FDBasal Diet Number:^FS")
			.AppendLine($" ^FO325,030^A0R,270,192^FD{dto.BasalId}^FS")
			.AppendLine(" ^FO350,020^A0R,25^FDProject: ^FS")
			.AppendLine(" ^FO350,320^A0R,25^FDStudy: ^FS")
			.AppendLine($" ^FO337,120^A0R,40^FD{dto.ProjectNumber}^FS")
			.AppendLine($" ^FO337,420^A0R,40^FD{dto.StudyNumber}^FS")
			.AppendLine(" ^FO300,020^A0R,25^FDSummary of Drug Concentrations:^FS")
			.AppendLine(" ^FO685,670^A0R,25^FDManufactured Date: ^FS")
			.Append(CreateDrugLines(dto.Drugs))
			.AppendLine($" ^FO685,900^A0R,40^FD{GetDateString(dto.ManufacturedDate)}^FS")
			.AppendLine(" ^FO100,990^A0N,35^FDComments:^FS")
			.AppendLine($" ^FO100,1030^A0N,35^FD{dto.Comment}^FS")
			.AppendLine($" ^FO100,1070^A0N,35^FD{dto.AdditionalComment}^FS")
			.Append(" ^XZ")
			.ToString();
	}

	public string GenerateZpl(PrintFeedLabelAdditiveDto dto)
	{
		return new StringBuilder()
			.AppendLine(" ^XA")
			.AppendLine(" ^CF0,25 ")
			.AppendLine(" ^FO740,020^A0R^FDLot No: ^FS")
			.AppendLine(" ^FO740,700^A0R^FD  Diet Preparation System ^FS")
			.AppendLine($" ^FO630,040^A0R,105,84^FD{dto.LotNumber}^FS")
			.AppendLine(" ^FO590,020^A0R^FDIdentification:^FS")
			.AppendLine($" ^FO475,040^A0R,105,84^FD{dto.Id}^FS")
			.AppendLine(" ^FO450,020^A0R^FDConcentration: ^FS")
			.AppendLine($" ^FO400,040^A0R,40^FD{dto.Concentration}^FS")
			.AppendLine(" ^FO350,020^A0R^FDExpiration Date: ^FS")
			.AppendLine($" ^FO305,040^A0R,40^FD{GetDateString(dto.ExpirationDate)}^FS")
			.AppendLine(" ^FO250,020^A0R,25^FDComments:^FS")
			.AppendLine($" ^FO200,040^A0R,40^FD{dto.Comment}^FS")
			.AppendLine($" ^FO150,040^A0R,40^FD{dto.AdditionalComment}^FS")
			.Append(" ^XZ")
			.ToString();
	}

	private static StringBuilder CreateDrugLines(IEnumerable<PrintFeedLabelDto.DrugRow>? drugs)
	{
		var drugArray = drugs?.ToArray() ?? Array.Empty<PrintFeedLabelDto.DrugRow>();

		if (drugArray.Length == 0)
		{
			return new StringBuilder()
				.AppendLine(" ^FO220,020^A0R,030^FDThere are no drugs in this diet^FS");
		}

		var charCount = drugArray.Max(x => x.DrugName?.Length);
		var iOffset1 = 260;
		var iOffset2 = (charCount * 20) + 42;

		var drugRows = new StringBuilder()
			.AppendLine($" ^FO260,020^A0R,030^FD{GetDrug(drugArray[0])}^FS")
			.AppendLine($" ^FO260,{iOffset2}^A0R,030^FD{GetConcentration(drugArray[0])}^FS");

		for (var i = 1; i < drugArray.Length; i++)
		{
			iOffset1 -= 40;

			drugRows
				.AppendLine($" ^FO{iOffset1},020^A0R,030^FD{GetDrug(drugArray[i])}^FS")
				.AppendLine($" ^FO{iOffset1},{iOffset2}^A0R,030^FD{GetConcentration(drugArray[i])}^FS");
		}

		return drugRows;
	}

	private static string? GetLotNumber(PrintFeedLabelDto dto, int bagNumber) => dto.NeedPrintBagNumbers ? $"{dto.LotNumber}-{bagNumber}" : dto.LotNumber;
	private static string? GetDateString(DateTime? dateTime) => dateTime.ToString(FormatStrings.NetDateFormat).ToUpper();
	private static string? GetDrug(PrintFeedLabelDto.DrugRow drug) => drug.DrugName;
	private static string? GetConcentration(PrintFeedLabelDto.DrugRow drug) => $"{drug.Concentration:N4} {drug.ConcentrationUnitOfMeasure.GetDisplayName()}";
}