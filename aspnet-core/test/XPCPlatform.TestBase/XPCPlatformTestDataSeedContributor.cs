using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace XPCPlatform;

public class XPCPlatformTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<IdentityRole, Guid> _identityRoleRepository;
    private readonly IRepository<IdentityUserRole> _identityUserRoleRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IGuidGenerator _guidGenerator;

    public XPCPlatformTestDataSeedContributor(
        IRepository<IdentityRole
        , Guid> identityRoleRepository
        , IRepository<IdentityUserRole> identityUserRoleRepository
        , UserManager<IdentityUser> userManager
        , IGuidGenerator guidGenerator)
    {
        _identityRoleRepository = identityRoleRepository;
        _identityUserRoleRepository = identityUserRoleRepository;
        _userManager = userManager;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Seed additional test data... */

            await SeedUserInformation();
    }

    private async Task SeedUserInformation()
    {
        //TODO: Bind this all variables into Configuration JSON File
        //---------------------------------
        string defaultUsername = "Admin";
        string defaultRole = "Admin";
        string defaultEmail = "admin@xpcplatform.com";
        string defaultPassword = "1q2w3E*";
        //---------------------------------

        // Check if the role already exists
        var adminRole = await _identityRoleRepository.FirstOrDefaultAsync(r => r.Name.ToLower() == defaultRole.ToLower());
        if (adminRole == null)
        {
            // If not, create the admin role
            adminRole = new IdentityRole(_guidGenerator.Create(), defaultRole);
            await _identityRoleRepository.InsertAsync(adminRole, true);
        }

        // Check if the user already exists
        var defaultUser = await _userManager.FindByNameAsync(defaultUsername);
        if (defaultUser == null)
        {
            var result = await _userManager.CreateAsync(new IdentityUser(_guidGenerator.Create(), defaultUsername, defaultEmail), defaultPassword);
            if (result.Succeeded)
            {
                defaultUser = await _userManager.FindByNameAsync(defaultUsername);
                if (defaultUser != null)
                {
                    // Check if the user already has the role assigned
                    var existingUserRole = await _identityUserRoleRepository.FirstOrDefaultAsync(ur => ur.UserId == defaultUser.Id && ur.RoleId == adminRole.Id);
                    if (existingUserRole == null)
                    {
                        // If not, assign the role to the user
                        var userRole = _userManager.AddToRolesAsync(defaultUser, new List<string> { defaultRole });
                    }
                }
            }
        }
    }

}
