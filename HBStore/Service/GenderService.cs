namespace HBStore.Service
{
    public class GenderService : ControllerBase, IGenderService
    {
        private readonly IGenderRepository _genderRepository;


        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

       public async Task<Gender>AddGender(Gender gender)
        {
            var result = _genderRepository.GetGenderByName(gender.Name);
            if(result is null)
            {
                return await _genderRepository.AddGender(gender);
            }
            throw new InvalidOperationException("Aynı isimde bir cinsiyet bulunmaktadir!");
        }

        public async Task DeleteGender(Gender gender)
        {
            var result = _genderRepository.GetGenderById(gender.Id);
            if(result is not null)
            {
                await _genderRepository.DeleteGender(gender);
            }
            throw new InvalidOperationException("Silinecek cinsiyet bulunamadi!");
        }

        public async Task<Gender> UpdateGender(Gender gender, int genderId)
        {
            var updatedGender = await _genderRepository.GetGenderById(genderId);
            if (updatedGender is not null)
            {
                updatedGender = gender;
                await _genderRepository.UpdateGender(gender);
                return gender;
            }
            throw new InvalidOperationException("Guncellenecek cinsiyet bulunamadi!");
        }

        public async Task<List<Gender>> GetAllGender()
        {
           return await _genderRepository.GetAllGender();
        }

        public async Task<Gender>GetGenderById(int genderId)
        {
            return await _genderRepository.GetGenderById(genderId);
        }

        public async Task<List<Gender>> GetGenderByName(string genderName)
        {
            return await _genderRepository.GetGenderByName(genderName);
        }

        public async Task<List<Gender>> GetGenderByUserId(int userId)
        {
            return await _genderRepository.GetGenderByUserId(userId);
        }


    }
}