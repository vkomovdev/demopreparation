namespace DietPreparation.Web.Models.Users;

public class UserListViewModel
{
	public required IEnumerable<UserListItemViewModel> Users { get; set; }
}