namespace IVeraControl.Model.Data
{
    public interface IDataIdentityPackageDetail
    {
        int Expires { get; }

        int Generated { get; }

        IPermission[] Permissions { get; }

        int PkAccount { get; }

        int PkAccountType { get; }

        int PkAccountChild { get; }

        int PkAccountParent { get; }

        int PkApp { get; }

        int PkOem { get; }

        string PkOemUser { get; }

        int PkPermissionRole { get; }

        int PkUser { get; }

        int PkServerAuth { get; }

        int PkServerAccount { get; }

        int PkServerEvent { get; }

        string ServerAuth { get; }

        string Username { get; }
    }
}
