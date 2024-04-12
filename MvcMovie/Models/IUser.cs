using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class IUser
{

    public void createNewUser();

    public void changePassword();

    public void changeEmail();

    public void changeFirstName();

    public void changeLastName();
}