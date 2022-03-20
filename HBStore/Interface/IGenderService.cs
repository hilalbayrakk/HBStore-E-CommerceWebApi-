namespace HBStore.Interface
{
    public interface IGenderService
    {
        Task<Gender> AddGender(Gender gender);
        Task DeleteGender(Gender gender);
        Task<Gender> UpdateGender(Gender gender, int genderId);
        Task<List<Gender>> GetAllGender();
        Task<Gender> GetGenderById(int genderId);
        Task<List<Gender>> GetGenderByName(string genderName);
        Task<List<Gender>> GetGenderByUserId(int userId);
    }
}