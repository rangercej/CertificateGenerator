﻿using System.Security.Cryptography.X509Certificates;
using Nightwolf.DerEncoder;

namespace Nightwolf.Certificates
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    /// <summary>
    /// Certificate static factory methods to quickly build certificates
    /// </summary>
    /// <remarks>
    /// Based on BR 1.6.2 <see cref="https://cabforum.org/wp-content/uploads/CA-Browser-Forum-BR-1.6.2.pdf"/>
    /// </remarks>
    public static class Factories
    {
        /// <summary>
        /// Key requirements are defined at BR sec 6.1.5
        /// </summary>
        private static readonly ECCurve DefaultCurve = ECCurve.NamedCurves.nistP384;
        private static readonly HashAlgorithmName DefaultHashAlgo = HashAlgorithmName.SHA256;

        /// <summary>Key usage flags template for CA certs</summary>
        public static readonly X509KeyUsageFlags CaKeyUsage = X509KeyUsageFlags.CrlSign
                                                       | X509KeyUsageFlags.KeyCertSign
                                                       | X509KeyUsageFlags.DigitalSignature;

        /// <summary>
        /// Construct a CAB forum compliant CA certificate
        /// </summary>
        /// <param name="subject">Certificate subject</param>
        /// <param name="notBefore">Not valid before</param>
        /// <param name="notAfter">Not valid after</param>
        /// <returns>CA certificate request template</returns>
        /// <remarks>CAB BR 7.1.2.1</remarks>
        public static Generator CreateCaTemplate(string subject, DateTime notBefore, DateTime notAfter)
        {
            var builder = new Generator(subject, DefaultCurve, DefaultHashAlgo);
            builder.SetValidityPeriod(notBefore, notAfter);
            builder.SetBasicConstraints(new X509BasicConstraintsExtension(true, false, 0, true));
            builder.SetKeyUsage(CaKeyUsage);

            return builder;
        }

        /// <summary>
        /// Construct a CAB forum compliant sub-CA certificate
        /// </summary>
        /// <param name="subject">Certificate subject</param>
        /// <param name="notBefore">Not valid before</param>
        /// <param name="notAfter">Not valid after</param>
        /// <param name="certPolicyStatement">Brief certificate policy statement (200 chars max)</param>
        /// <returns>Sub-CA certificate request template</returns>
        /// <remarks>CAB BR 7.2.2.2</remarks>
        public static Generator CreateSubCaTemplate(string subject, DateTime notBefore, DateTime notAfter, string certPolicyStatement = null, Uri certPolicyUrl = null)
        {
            if (certPolicyStatement != null && certPolicyStatement.Length > 200)
            {
                // RFC 5280, sec 4.2.1.4
                throw new ArgumentException("Policy too long", nameof(certPolicyStatement));
            }

            var builder = new Generator(subject, DefaultCurve, DefaultHashAlgo);
            builder.SetValidityPeriod(notBefore, notAfter);
            builder.SetCertificatePolicy(certPolicyStatement, certPolicyUrl);

            return builder;
        }
        /// <summary>
        /// Construct a CAB forum compliant subject certificate
        /// </summary>
        /// <param name="subject">Certificate subject</param>
        /// <param name="notBefore">Not valid before</param>
        /// <param name="notAfter">Not valid after</param>
        /// <returns>Generated CA certificate object</returns>
        /// <remarks>CAB BR 7.1.2.2</remarks>
        public static Generator CreateSubjectTemplate(List<string> subject, DateTime notBefore, DateTime notAfter)
        {
            var builder = new Generator(subject[0], DefaultCurve, DefaultHashAlgo);
            builder.SetValidityPeriod(notBefore, notAfter);

            foreach (var s in subject)
            {
                builder.AddSubjectAltName(s);
            }

            return builder;
        }
    }
}