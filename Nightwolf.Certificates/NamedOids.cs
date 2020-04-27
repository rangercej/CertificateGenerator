﻿namespace Nightwolf.Certificates
{
    using System.Security.Cryptography;

    /// <summary>
    /// Named OIDs from RFC 5280
    /// </summary>
    /// <remarks>
    /// Names are based on the that in the RFC, so if (for example)
    /// the name in the RFC is id-ce-certificatePolicies, we turn
    /// this into the form: IdCeCertificiatePolicies.
    /// </remarks>
    public static class NamedOids
    {
        public static class RootArcs
        {
            public static readonly Oid IdPkix = ConstructOid("1.3.6.1.5.5.7");
            public static readonly Oid IdPe = ConstructOid(IdPkix, "1");
        }

        public static class InformationAccess
        {
            public static readonly Oid IdPeAuthorityInfoAccess = ConstructOid(RootArcs.IdPe, "1");
            public static readonly Oid IdPeSubjectInfoAccess = ConstructOid(RootArcs.IdPe, "11");
        }

        public static class CertificateExtensions
        {
            public static readonly Oid IdCe = ConstructOid("2.5.29");
            public static readonly Oid IdCeBasicConstraints = ConstructOid(IdCe, "19");
            public static readonly Oid IdCeCrlDistributionPoints = ConstructOid(IdCe, "31");
            public static readonly Oid IdCeExtKeyUsage = ConstructOid(IdCe, "37");
        }

        public static class CertificatePolicies
        {
            public static readonly Oid IdCeCertificatePolicies = ConstructOid(CertificateExtensions.IdCe, "32");
            public static readonly Oid AnyPolicy = ConstructOid(CertificateExtensions.IdCe, "32.0");
        }

        public static class PolicyQualifiers
        {
            public static readonly Oid IdQt = ConstructOid(RootArcs.IdPkix, "2");
            public static readonly Oid IdQtCps = ConstructOid(IdQt, "1");
            public static readonly Oid IdQtUnotice = ConstructOid(IdQt, "2");
        }
        
        public static class AccessDescriptors
        {
            public static readonly Oid IdAd = ConstructOid(RootArcs.IdPkix, "48");
            public static readonly Oid IdAdOcsp = ConstructOid(IdAd, "1");
            public static readonly Oid IdAdCaIssuers = ConstructOid(IdAd, "2");
        }

        /// <summary>Certificate extended uses</summary>
        public static class CertificateUses
        {
            public static readonly Oid IdKp = ConstructOid(RootArcs.IdPkix, "3");
            public static readonly Oid IdKpServerAuth = ConstructOid(IdKp, "1");
            public static readonly Oid IdKpClientAuth = ConstructOid(IdKp, "2");
            public static readonly Oid IdKpCodeSigning = ConstructOid(IdKp, "3");
            public static readonly Oid IdKpEmailProtection = ConstructOid(IdKp, "4");
            public static readonly Oid IdKpIpsecEndSystem = ConstructOid(IdKp, "5");
            public static readonly Oid IdKpIpsecTunnel = ConstructOid(IdKp, "6");
            public static readonly Oid IdKpIpsecUser = ConstructOid(IdKp, "7");
            public static readonly Oid IdKpTimeStamping = ConstructOid(IdKp, "8");
            public static readonly Oid IdKpOcspSigning = ConstructOid(IdKp, "9");
            public static readonly Oid AnyExtendedKeyUsage = ConstructOid(CertificateExtensions.IdCeExtKeyUsage, "0");
            public static readonly Oid IdKpIkeIntermediate = ConstructOid("1.3.6.1.5.5.8.2.2");
        }


        /// <summary>Microsoft-specific extended use OIDs</summary>
        /// <remarks>Source: https://docs.microsoft.com/en-us/windows/desktop/api/certenroll/nn-certenroll-ix509extensionenhancedkeyusage </remarks>
        public static class Microsoft
        {
            public static readonly Oid XcnOidMicrosoft = ConstructOid("1.3.6.1.4.1.311");
            public static readonly Oid XcnOidKpCtlUsageSigning = ConstructOid(XcnOidMicrosoft, "10.3.1");
            public static readonly Oid XcnOidKpTimeStampSigning = ConstructOid(XcnOidMicrosoft, "10.3.2");
            public static readonly Oid XcnOidKpEfs = ConstructOid(XcnOidMicrosoft, "10.3.4");
            public static readonly Oid XcnOidEfsRecovery = ConstructOid(XcnOidMicrosoft, "10.3.4.1");
            public static readonly Oid XcnOidWhqlCrypto = ConstructOid(XcnOidMicrosoft, "10.3.5");
            public static readonly Oid XcnOidNt5Crypto = ConstructOid(XcnOidMicrosoft, "10.3.7");
            public static readonly Oid XcnOidOemWhqlCrypto = ConstructOid(XcnOidMicrosoft, "10.3.7");
            public static readonly Oid XcnOidEmbeddedNtCrypto = ConstructOid(XcnOidMicrosoft, "10.3.8");
            public static readonly Oid XcnOidRootListSigner = ConstructOid(XcnOidMicrosoft, "10.3.9");
            public static readonly Oid XcnOidKpQualifiedSubordination = ConstructOid(XcnOidMicrosoft, "10.3.10");
            public static readonly Oid XcnOidKpKeyRecovery = ConstructOid(XcnOidMicrosoft, "10.3.11");
            public static readonly Oid XcnOidKpDocumentSigning = ConstructOid(XcnOidMicrosoft, "10.3.12");
            public static readonly Oid XcnOidKpLifetimeSigning = ConstructOid(XcnOidMicrosoft, "10.3.13");
            public static readonly Oid XcnOidDrm = ConstructOid(XcnOidMicrosoft, "10.5.1");
            public static readonly Oid XcnOidLicenses = ConstructOid(XcnOidMicrosoft, "10.6.1");
            public static readonly Oid XcnOidLicenseServer = ConstructOid(XcnOidMicrosoft, "10.6.2");
            public static readonly Oid XcnOidAnyApplicationPolicy = ConstructOid(XcnOidMicrosoft, "10.12.1");
            public static readonly Oid XcnOidAutoEnrollCtlUsage = ConstructOid(XcnOidMicrosoft, "20.1");
            public static readonly Oid XcnOidEnrollmentAgent = ConstructOid(XcnOidMicrosoft, "20.2.1");
            public static readonly Oid XcnOidDsEmailReplication = ConstructOid(XcnOidMicrosoft, "21.19");
            public static readonly Oid XcnOidKpSmartcardLogon = ConstructOid(XcnOidMicrosoft, "20.2.2");
            public static readonly Oid XcnOidKpCaExchange = ConstructOid(XcnOidMicrosoft, "21.5");
            public static readonly Oid XcnOidKpKeyRecoveryAgent = ConstructOid(XcnOidMicrosoft, "21.6");
            public static readonly Oid XcnOidPkixKpServerAuth = NamedOids.CertificateUses.IdKpServerAuth;
            public static readonly Oid XcnOidPkixKpClientAuth = NamedOids.CertificateUses.IdKpClientAuth;
            public static readonly Oid XcnOidPkixKpCodeSigning = NamedOids.CertificateUses.IdKpCodeSigning;
            public static readonly Oid XcnOidPkixKpEmailProtection = NamedOids.CertificateUses.IdKpEmailProtection;
            public static readonly Oid XcnOidPkixKpIpsecEndSystem = NamedOids.CertificateUses.IdKpIpsecEndSystem;
            public static readonly Oid XcnOidPkixKpIpsecTunnel = NamedOids.CertificateUses.IdKpIpsecTunnel;
            public static readonly Oid XcnOidPkixKpIpsecUser = NamedOids.CertificateUses.IdKpIpsecUser;
            public static readonly Oid XcnOidPkixKpOcspSigning = NamedOids.CertificateUses.IdKpOcspSigning;
            public static readonly Oid XcnOidPkixKpTimestampSigning = NamedOids.CertificateUses.IdKpTimeStamping;
            public static readonly Oid XcnOidIpsecKpIkeIntermediate = NamedOids.CertificateUses.IdKpIpsecEndSystem;
        }

        /// <summary>Non-standard OIDs</summary>
        /// <remarks>Not part of RFC 5280, and officially deprecated, but 
        /// popular none the less where building certificates for internal use.</remarks>
        public static class NonStandard
        {
            public static readonly Oid NsComment = ConstructOid("2.16.840.1.113730.1.13");
        }

        /// <summary>Public key algorithm OIDs from RFC3279</summary>
        public static class KeyAlgorithm
        {
            public static readonly Oid RsaEncryption = ConstructOid("1.2.840.113549.1.1.1");
            public static readonly Oid IdEcPublicKey = ConstructOid("1.2.840.10045.2.1");
        }

        /// <summary>
        /// Create a new OID object
        /// </summary>
        /// <param name="oid">OID to create</param>
        /// <returns>OID object</returns>
        /// <remarks>Exists only to make consistent the construction and maintenance 
        /// of OIDs in the section above, so all OIDs are created with the same method.
        /// </remarks>
        private static Oid ConstructOid(string oid)
        {
            return new Oid(oid);
        }

        /// <summary>
        /// Create a new OID child from a parent OID
        /// </summary>
        /// <param name="parent">Parent OID</param>
        /// <param name="child">Child suffix of OID</param>
        /// <returns>OID object</returns>
        private static Oid ConstructOid(Oid parent, string child)
        {
            return new Oid($"{parent.Value}.{child}");
        }
    }
}
