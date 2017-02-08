using SchoolBus.WS.CCW.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolbus.WS.CcwFacade.Service.Mocks
{
    internal static class MockClientOrganization
    {
        public static ClientOrganization GetClientOrganization()
        {
            return new ClientOrganization
            {
                clientNumber = "1234",
                clientType = "",
                currentAddressReference = "",
                displayName = "Test",
                documentType = "Test",
                documentTypeDescription = "",
                drivers = "",
                effectiveDate = null,

                financialResponsibilityInformation = new FinancialResponsibilityInformation(),
                frFiling = "",
                lastUpdated = DateTime.UtcNow,
                lastUpdatedBy = "",
                mcAuthority = "",
                multipleFrsExist = false,
                name1 = "Test User",
                name2 = "",
                name3 = "",
                noFrExists = false,
                nscCertificate = "1234",
                nscInformation = new NscInformation(),
                organizationComment = "test",
                organizationDocumentId = "",
                organizationTypeCode = "",
                organizationTypeDescription = "",
                prorateAccount = "",
                statusCode = "Active",
                statusDescription = "",
                vehicles = ""
            };
        }
    }
}
