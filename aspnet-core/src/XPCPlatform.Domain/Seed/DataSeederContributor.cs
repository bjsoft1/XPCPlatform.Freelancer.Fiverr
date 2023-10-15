using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace XPCPlatform.Seed
{
    //public class DataSeederContributor : IDataSeedContributor, ITransientDependency
    //{
    //    private readonly IRepository<IdentityRole, Guid> _identityRoleRepository;
    //    private readonly IRepository<IdentityUserRole> _identityUserRoleRepository;
    //    private readonly UserManager<IdentityUser> _userManager;
    //    private readonly IGuidGenerator _guidGenerator;
    //    public DataSeederContributor(
    //        IRepository<IdentityRole, Guid> identityRoleRepository
    //        , IRepository<IdentityUserRole> identityUserRoleRepository
    //        , IGuidGenerator guidGenerator
    //        , UserManager<IdentityUser> userManager)
    //    {
    //        _identityRoleRepository = identityRoleRepository;
    //        _identityUserRoleRepository = identityUserRoleRepository;
    //        _guidGenerator = guidGenerator;
    //        _userManager = userManager;
    //    }

    //    [UnitOfWork]
    //    public async Task SeedAsync(DataSeedContext context)
    //    {
    //        await SeedUserInformation();
    //    }
    //}
}
