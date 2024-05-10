using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmart.Models;

public interface IUser
{

    public bool RegisterUser();

    public void changePassword(string newPassword);

    public void changeEmail(string newEmail);

    public void changeFirstName(string newFirstName);

    public void changeLastName(string newLastName);
}