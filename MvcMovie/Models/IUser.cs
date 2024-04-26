using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public interface IUser
{

    public bool RegisterUser();

    public void changePassword();

    public void changeEmail();

    public void changeFirstName();

    public void changeLastName();
}