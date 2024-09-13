using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Application.Queries.Requests.Drugs;
using DietPreparation.Application.Queries.Responses.Drugs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.ServicesApi.Controllers;

[ApiController]
[Route("api/drug")]
public class DrugController : ControllerBase
{
	private readonly IMediator _mediatr;

	public DrugController(IMediator mediatr)
	{
		_mediatr = mediatr;
	}

	[HttpGet]
	public async Task<ActionResult<GetDrugsQueryResponse>> GetDrugs(GetDrugsQueryRequest request)
	{
		return await _mediatr.Send(request);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<GetDrugQueryResponse>> GetDrug(int id)
	{
		return await _mediatr.Send(new GetDrugQueryRequest { DrugId = id });
	}

	[HttpPost]
	public async Task<ActionResult<CreateUpdateDrugResponse>> CreateUpdateUser(CreateUpdateDrugRequest request)
	{
		return await _mediatr.Send(request);
	}
}
