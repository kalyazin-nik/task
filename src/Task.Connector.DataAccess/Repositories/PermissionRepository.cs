﻿using Task.Connector.AppServices.Permission.Repository;
using Task.Connector.Contract.Permission;
using Task.Connector.DataAccess.Repositories.Repository;
using Task.Connector.Domain;
using Task.Connector.Infrastructure.Extensions;
using Task.Integration.Data.Models;

namespace Task.Connector.DataAccess.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly IRepository<ConnectorDbContext> _repository;
    private readonly ILogger _logger;

    public PermissionRepository(IRepository<ConnectorDbContext> repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<Integration.Data.Models.Models.Permission> GetAllPermissions()
    {
        var permissions = new List<Integration.Data.Models.Models.Permission>();

        _repository.GetAll<ItRole>()
            .ForEach(x => permissions.Add(new Integration.Data.Models.Models.Permission(x.Id.ToString(), x.Name, x.CorporatePhoneNumber)));

        _repository.GetAll<RequestRight>()
            .ForEach(x => permissions.Add(new Integration.Data.Models.Models.Permission(x.Id.ToString(), x.Name, string.Empty)));

        return permissions;
    }

    public void AddRight(RightDto right)
    {
        switch (right.Permission)
        {
            case Infrastructure.Common.Enums.Permissions.Role:
                _repository.Create(new UserItRole { RoleId = right.RightId, UserId = right.Login });
                return;
            case Infrastructure.Common.Enums.Permissions.Request:
                _repository.Create(new UserRequestRight { RightId = right.RightId, UserId = right.Login });
                return;
            default: throw new NotImplementedException();
        }
    }

    public IEnumerable<string> GetUserPermissions(string login)
    {
        return _repository.GetByPredicate<UserRequestRight>(x => x.UserId == login)
            .Select(x => x.RightId.ToString());
    }

    public void RemoveUserPermission(RightDto right)
    {
        switch (right.Permission)
        {
            case Infrastructure.Common.Enums.Permissions.Role:
                _repository.RemoveByPredicate<UserItRole>(x => x.UserId == right.Login && x.RoleId == right.RightId);
                return;
            case Infrastructure.Common.Enums.Permissions.Request:
                _repository.RemoveByPredicate<UserRequestRight>(x => x.UserId == right.Login && x.RightId == right.RightId);
                return;
            default: throw new NotImplementedException();
        }
    }
}