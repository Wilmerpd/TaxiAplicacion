public class UserRole
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public Usuario Usuario { get; set; }
    public Rol Rol { get; set; }
}
