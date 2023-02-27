using WebApplication1.Model;

namespace WebApplication1.Interface
{
    public interface IOffice  //Strucer เมื่อมีอะไรก็ตามมา สืบทอด 
    {
        public Task<IEnumerable<OfficeModel>> GetOfficeAllAsync();
        public Task<OfficeModel> GetOfficeByIdAsync(int id);
        public Task InsertOfficeAsync (OfficeModel model); 
        public Task UpdateOfficeAsync (int id ,OfficeModel model);
        public Task DeleteOfficeAsync (int id);
    }
}
