using System.ComponentModel.DataAnnotations;

namespace Image_Board_Web_Service.Models.OrmModels;

public class OrmBaseModel
{
    public OrmBaseModel()
    {
        CreationDate = DateTime.Now;
    }

    [Key]
    public int Id { get; set; }
    public DateTime CreationDate { get; init; }
}