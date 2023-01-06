namespace WebApi.Profile
{
    public class JobApplicationProfile : AutoMapper.Profile
    {
        public JobApplicationProfile()
        {
            CreateMap<Entity.JobApplication, DTO.JobApplication>();
            CreateMap<DTO.JobApplication, Entity.JobApplication>();
        }
    }
}
