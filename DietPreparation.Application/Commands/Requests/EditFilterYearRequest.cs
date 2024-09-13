using DietPreparation.Application.Commands.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPreparation.Application.Commands.Requests;
public class EditFilterYearRequest: IRequest<EditFilterYearResponse>
{
	public int Year { get; set; }
}
