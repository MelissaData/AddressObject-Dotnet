using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace MelissaData {
	public class mdAddr : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			ErrorNone = 0,
			ErrorOther = 1,
			ErrorOutOfMemory = 2,
			ErrorRequiredFileNotFound = 3,
			ErrorFoundOldFile = 4,
			ErrorDatabaseExpired = 5,
			ErrorLicenseExpired = 6
		}
		public enum AccessType {
			Local = 0,
			Remote = 1
		}
		public enum DiacriticsMode {
			Auto = 0,
			On = 1,
			Off = 2
		}
		public enum StandardizeMode {
			ShortFormat = 0,
			LongFormat = 1,
			AutoFormat = 2
		}
		public enum SuiteParseMode {
			ParseSuite = 0,
			CombineSuite = 1
		}
		public enum AliasPreserveMode {
			ConvertAlias = 0,
			PreserveAlias = 1
		}
		public enum AutoCompletionMode {
			AutoCompleteSingleSuite = 0,
			AutoCompleteRangedSuite = 1,
			AutoCompletePlaceHolderSuite = 2,
			AutoCompleteNoSuite = 3
		}
		public enum ResultCdDescOpt {
			ResultCodeDescriptionLong = 0,
			ResultCodeDescriptionShort = 1
		}
		public enum MailboxLookupMode {
			MailboxNone = 0,
			MailboxExpress = 1,
			MailboxPremium = 2
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdAddrUnmanaged {
			[DllImport("mdAddr", EntryPoint = "mdAddrCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrCreate();
			[DllImport("mdAddr", EntryPoint = "mdAddrDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrDestroy(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrInitialize", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrInitialize(IntPtr i, IntPtr p1, IntPtr p2, IntPtr p3);
			[DllImport("mdAddr", EntryPoint = "mdAddrInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrInitializeDataFiles(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetInitializeErrorString(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrSetLicenseString(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetBuildNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDatabaseDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetExpirationDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLicenseExpirationDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCanadianDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCanadianDatabaseDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCanadianExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCanadianExpirationDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToUSFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToUSFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToCanadaFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToCanadaFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToDPVDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToDPVDataFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToLACSLinkDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToLACSLinkDataFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToSuiteLinkDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToSuiteLinkDataFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToSuiteFinderDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToSuiteFinderDataFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToRBDIFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToRBDIFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetRBDIDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetRBDIDatabaseDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPathToAddrKeyDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToAddrKeyDataFiles(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrClearProperties", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrClearProperties(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrResetDPV", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetDPV(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetCASSEnable", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCASSEnable(IntPtr i, Int32 p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetUseUSPSPreferredCityNames", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetUseUSPSPreferredCityNames(IntPtr i, Int32 p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetDiacritics", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetDiacritics(IntPtr i, Int32 p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetStatusCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetStatusCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetErrorCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetErrorCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetErrorString(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetResults", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetResults(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetResultCodeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetResultCodeDescription(IntPtr i, IntPtr resultCode, Int32 opt);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_B1_ProcessorName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_B1_ProcessorName(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_B4_ListName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_B4_ListName(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_D3_Name", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_Name(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_D3_Company", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_Company(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_D3_Address", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_Address(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_D3_City", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_City(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_D3_State", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_State(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPS3553_D3_ZIP", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_ZIP(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetFormPS3553", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetFormPS3553(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSaveFormPS3553", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrSaveFormPS3553(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrResetFormPS3553", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetFormPS3553(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrResetFormPS3553Counter", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetFormPS3553Counter(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetStandardizationType", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetStandardizationType(IntPtr i, Int32 mode);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetSuiteParseMode", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSuiteParseMode(IntPtr i, Int32 mode);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetAliasMode", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetAliasMode(IntPtr i, Int32 mode);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetFormSOA", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetFormSOA(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSaveFormSOA", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSaveFormSOA(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrResetFormSOA", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetFormSOA(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetSOACustomerInfo", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSOACustomerInfo(IntPtr i, IntPtr customerName, IntPtr customerAddress);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetSOACPCNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSOACPCNumber(IntPtr i, IntPtr CPCNumber);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSOACustomerInfo", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOACustomerInfo(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSOACPCNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOACPCNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSOATotalRecords", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetSOATotalRecords(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSOAAAPercentage", CallingConvention = CallingConvention.Cdecl)]
			public static extern float mdAddrGetSOAAAPercentage(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSOAAAExpiryDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOAAAExpiryDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSOASoftwareInfo", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOASoftwareInfo(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSOAErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOAErrorString(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCompany(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetLastName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetLastName(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetAddress(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetAddress2", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetAddress2(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetLastLine", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetLastLine(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetSuite", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSuite(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCity(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetState(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetZip(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetPlus4", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPlus4(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetUrbanization", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetUrbanization(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedAddressRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedAddressRange(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedPreDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedPreDirection(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedStreetName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedStreetName(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedSuffix", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedSuffix(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedPostDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedPostDirection(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedSuiteName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedSuiteName(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedSuiteRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedSuiteRange(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedRouteService", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedRouteService(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedLockBox", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedLockBox(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetParsedDeliveryInstallation", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedDeliveryInstallation(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetCountryCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCountryCode(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrVerifyAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrVerifyAddress(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCompany(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetLastName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLastName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddress(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetAddress2", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddress2(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSuite", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSuite(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCity(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCityAbbreviation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCityAbbreviation(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetState(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetZip(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPlus4", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetPlus4(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCarrierRoute", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCarrierRoute(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDeliveryPointCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDeliveryPointCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDeliveryPointCheckDigit", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDeliveryPointCheckDigit(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCountyFips", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCountyFips(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCountyName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCountyName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetAddressTypeCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddressTypeCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetAddressTypeString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddressTypeString(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetUrbanization", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetUrbanization(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCongressionalDistrict", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCongressionalDistrict(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetLACS", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLACS(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetLACSLinkIndicator", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLACSLinkIndicator(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPrivateMailbox", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetPrivateMailbox(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetTimeZoneCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetTimeZoneCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetTimeZone", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetTimeZone(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetMsa", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetMsa(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPmsa", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetPmsa(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDefaultFlagIndicator", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDefaultFlagIndicator(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSuiteStatus", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSuiteStatus(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetEWSFlag", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetEWSFlag(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCMRA", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCMRA(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDsfVacant", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDsfVacant(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetCountryCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCountryCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetZipType", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetZipType(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetFalseTable", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetFalseTable(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDPVFootnotes", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDPVFootnotes(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetLACSLinkReturnCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLACSLinkReturnCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetSuiteLinkReturnCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSuiteLinkReturnCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetRBDI", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetRBDI(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetELotNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetELotNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetELotOrder", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetELotOrder(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetAddressKey", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddressKey(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetMelissaAddressKey", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetMelissaAddressKey(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetMelissaAddressKeyBase", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetMelissaAddressKeyBase(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetOutputParameter", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetOutputParameter(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetInputParameter", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrSetInputParameter(IntPtr i, IntPtr p1, IntPtr p2);
			[DllImport("mdAddr", EntryPoint = "mdAddrFindSuggestion", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrFindSuggestion(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrFindSuggestionNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrFindSuggestionNext(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDsfNoStats", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDsfNoStats(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetDsfDNA", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDsfDNA(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_B6_TotalRecords", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_B6_TotalRecords(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_C1a_ZIP4Coded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1a_ZIP4Coded(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_C1c_DPBCAssigned", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1c_DPBCAssigned(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_C1d_FiveDigitCoded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1d_FiveDigitCoded(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_C1e_CRRTCoded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1e_CRRTCoded(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_C1f_eLOTAssigned", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1f_eLOTAssigned(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_E_HighRiseDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_HighRiseDefault(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_E_HighRiseExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_HighRiseExact(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_E_RuralRouteDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_RuralRouteDefault(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_E_RuralRouteExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_RuralRouteExact(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetZip4HRDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4HRDefault(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetZip4HRExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4HRExact(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetZip4RRDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4RRDefault(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetZip4RRExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4RRExact(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_E_LACSCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_LACSCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_E_EWSCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_EWSCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_E_DPVCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_DPVCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_POBoxCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_POBoxCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_HCExactCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_HCExactCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_FirmCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_FirmCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_GenDeliveryCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_GenDeliveryCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_MilitaryZipCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_MilitaryZipCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_NonDeliveryCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_NonDeliveryCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_StreetCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_StreetCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_HCDefaultCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_HCDefaultCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_OtherCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_OtherCount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_LacsLinkCodeACount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCodeACount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode00Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode00Count(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode14Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode14Count(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode92Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode92Count(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode09Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode09Count(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_SuiteLinkCodeACount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_SuiteLinkCodeACount(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetPS3553_X_SuiteLinkCode00Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_SuiteLinkCode00Count(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedAddressRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedAddressRange(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedPreDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPreDirection(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedStreetName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedStreetName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedSuffix", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedSuffix(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedPostDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPostDirection(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedSuiteName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedSuiteName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedSuiteRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedSuiteRange(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedPrivateMailboxName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPrivateMailboxName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedPrivateMailboxNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPrivateMailboxNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedGarbage", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedGarbage(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedRouteService", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedRouteService(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedLockBox", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedLockBox(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetParsedDeliveryInstallation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedDeliveryInstallation(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdAddrSetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetReserved(IntPtr i, IntPtr p1, IntPtr p2);
			[DllImport("mdAddr", EntryPoint = "mdAddrGetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetReserved(IntPtr i, IntPtr p1);
		}

		public mdAddr() {
			i = mdAddrUnmanaged.mdAddrCreate();
		}

		~mdAddr() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdAddrUnmanaged.mdAddrDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public ProgramStatus Initialize(string p1, string p2, string p3) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			EncodedString u_p3 = new EncodedString(p3);
			return (ProgramStatus)mdAddrUnmanaged.mdAddrInitialize(i, u_p1.GetPtr(), u_p2.GetPtr(), u_p3.GetPtr());
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)mdAddrUnmanaged.mdAddrInitializeDataFiles(i);
		}

		public string GetInitializeErrorString() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetInitializeErrorString(i));
		}

		public bool SetLicenseString(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdAddrUnmanaged.mdAddrSetLicenseString(i, u_p1.GetPtr()) != 0);
		}

		public string GetBuildNumber() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetBuildNumber(i));
		}

		public string GetDatabaseDate() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDatabaseDate(i));
		}

		public string GetExpirationDate() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetExpirationDate(i));
		}

		public string GetLicenseExpirationDate() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetLicenseExpirationDate(i));
		}

		public string GetCanadianDatabaseDate() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCanadianDatabaseDate(i));
		}

		public string GetCanadianExpirationDate() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCanadianExpirationDate(i));
		}

		public void SetPathToUSFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToUSFiles(i, u_p1.GetPtr());
		}

		public void SetPathToCanadaFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToCanadaFiles(i, u_p1.GetPtr());
		}

		public void SetPathToDPVDataFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToDPVDataFiles(i, u_p1.GetPtr());
		}

		public void SetPathToLACSLinkDataFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToLACSLinkDataFiles(i, u_p1.GetPtr());
		}

		public void SetPathToSuiteLinkDataFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToSuiteLinkDataFiles(i, u_p1.GetPtr());
		}

		public void SetPathToSuiteFinderDataFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToSuiteFinderDataFiles(i, u_p1.GetPtr());
		}

		public void SetPathToRBDIFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToRBDIFiles(i, u_p1.GetPtr());
		}

		public string GetRBDIDatabaseDate() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetRBDIDatabaseDate(i));
		}

		public void SetPathToAddrKeyDataFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPathToAddrKeyDataFiles(i, u_p1.GetPtr());
		}

		public void ClearProperties() {
			mdAddrUnmanaged.mdAddrClearProperties(i);
		}

		public void ResetDPV() {
			mdAddrUnmanaged.mdAddrResetDPV(i);
		}

		public void SetCASSEnable(int p1) {
			mdAddrUnmanaged.mdAddrSetCASSEnable(i, p1);
		}

		public void SetUseUSPSPreferredCityNames(int p1) {
			mdAddrUnmanaged.mdAddrSetUseUSPSPreferredCityNames(i, p1);
		}

		public void SetDiacritics(DiacriticsMode p1) {
			mdAddrUnmanaged.mdAddrSetDiacritics(i, (int)p1);
		}

		public string GetStatusCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetStatusCode(i));
		}

		public string GetErrorCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetErrorCode(i));
		}

		public string GetErrorString() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetErrorString(i));
		}

		public string GetResults() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetResults(i));
		}

		public string GetResultCodeDescription(string resultCode, ResultCdDescOpt opt) {
			EncodedString u_resultCode = new EncodedString(resultCode);
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetResultCodeDescription(i, u_resultCode.GetPtr(), (int)opt));
		}

		public string GetResultCodeDescription(string resultCode) {
			EncodedString u_resultCode = new EncodedString(resultCode);
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetResultCodeDescription(i, u_resultCode.GetPtr(), (int)ResultCdDescOpt.ResultCodeDescriptionLong));
		}

		public void SetPS3553_B1_ProcessorName(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_B1_ProcessorName(i, u_p1.GetPtr());
		}

		public void SetPS3553_B4_ListName(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_B4_ListName(i, u_p1.GetPtr());
		}

		public void SetPS3553_D3_Name(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_D3_Name(i, u_p1.GetPtr());
		}

		public void SetPS3553_D3_Company(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_D3_Company(i, u_p1.GetPtr());
		}

		public void SetPS3553_D3_Address(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_D3_Address(i, u_p1.GetPtr());
		}

		public void SetPS3553_D3_City(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_D3_City(i, u_p1.GetPtr());
		}

		public void SetPS3553_D3_State(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_D3_State(i, u_p1.GetPtr());
		}

		public void SetPS3553_D3_ZIP(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPS3553_D3_ZIP(i, u_p1.GetPtr());
		}

		public string GetFormPS3553() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetFormPS3553(i));
		}

		public bool SaveFormPS3553(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdAddrUnmanaged.mdAddrSaveFormPS3553(i, u_p1.GetPtr()) != 0);
		}

		public void ResetFormPS3553() {
			mdAddrUnmanaged.mdAddrResetFormPS3553(i);
		}

		public void ResetFormPS3553Counter() {
			mdAddrUnmanaged.mdAddrResetFormPS3553Counter(i);
		}

		public void SetStandardizationType(StandardizeMode mode) {
			mdAddrUnmanaged.mdAddrSetStandardizationType(i, (int)mode);
		}

		public void SetSuiteParseMode(SuiteParseMode mode) {
			mdAddrUnmanaged.mdAddrSetSuiteParseMode(i, (int)mode);
		}

		public void SetAliasMode(AliasPreserveMode mode) {
			mdAddrUnmanaged.mdAddrSetAliasMode(i, (int)mode);
		}

		public string GetFormSOA() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetFormSOA(i));
		}

		public void SaveFormSOA(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSaveFormSOA(i, u_p1.GetPtr());
		}

		public void ResetFormSOA() {
			mdAddrUnmanaged.mdAddrResetFormSOA(i);
		}

		public void SetSOACustomerInfo(string customerName, string customerAddress) {
			EncodedString u_customerName = new EncodedString(customerName);
			EncodedString u_customerAddress = new EncodedString(customerAddress);
			mdAddrUnmanaged.mdAddrSetSOACustomerInfo(i, u_customerName.GetPtr(), u_customerAddress.GetPtr());
		}

		public void SetSOACPCNumber(string CPCNumber) {
			EncodedString u_CPCNumber = new EncodedString(CPCNumber);
			mdAddrUnmanaged.mdAddrSetSOACPCNumber(i, u_CPCNumber.GetPtr());
		}

		public string GetSOACustomerInfo() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSOACustomerInfo(i));
		}

		public string GetSOACPCNumber() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSOACPCNumber(i));
		}

		public int GetSOATotalRecords() {
			return mdAddrUnmanaged.mdAddrGetSOATotalRecords(i);
		}

		public float GetSOAAAPercentage() {
			return mdAddrUnmanaged.mdAddrGetSOAAAPercentage(i);
		}

		public string GetSOAAAExpiryDate() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSOAAAExpiryDate(i));
		}

		public string GetSOASoftwareInfo() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSOASoftwareInfo(i));
		}

		public string GetSOAErrorString() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSOAErrorString(i));
		}

		public void SetCompany(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetCompany(i, u_p1.GetPtr());
		}

		public void SetLastName(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetLastName(i, u_p1.GetPtr());
		}

		public void SetAddress(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetAddress(i, u_p1.GetPtr());
		}

		public void SetAddress2(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetAddress2(i, u_p1.GetPtr());
		}

		public void SetLastLine(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetLastLine(i, u_p1.GetPtr());
		}

		public void SetSuite(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetSuite(i, u_p1.GetPtr());
		}

		public void SetCity(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetCity(i, u_p1.GetPtr());
		}

		public void SetState(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetState(i, u_p1.GetPtr());
		}

		public void SetZip(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetZip(i, u_p1.GetPtr());
		}

		public void SetPlus4(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetPlus4(i, u_p1.GetPtr());
		}

		public void SetUrbanization(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetUrbanization(i, u_p1.GetPtr());
		}

		public void SetParsedAddressRange(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedAddressRange(i, u_p1.GetPtr());
		}

		public void SetParsedPreDirection(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedPreDirection(i, u_p1.GetPtr());
		}

		public void SetParsedStreetName(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedStreetName(i, u_p1.GetPtr());
		}

		public void SetParsedSuffix(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedSuffix(i, u_p1.GetPtr());
		}

		public void SetParsedPostDirection(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedPostDirection(i, u_p1.GetPtr());
		}

		public void SetParsedSuiteName(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedSuiteName(i, u_p1.GetPtr());
		}

		public void SetParsedSuiteRange(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedSuiteRange(i, u_p1.GetPtr());
		}

		public void SetParsedRouteService(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedRouteService(i, u_p1.GetPtr());
		}

		public void SetParsedLockBox(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedLockBox(i, u_p1.GetPtr());
		}

		public void SetParsedDeliveryInstallation(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetParsedDeliveryInstallation(i, u_p1.GetPtr());
		}

		public void SetCountryCode(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdAddrUnmanaged.mdAddrSetCountryCode(i, u_p1.GetPtr());
		}

		public bool VerifyAddress() {
			return (mdAddrUnmanaged.mdAddrVerifyAddress(i) != 0);
		}

		public string GetCompany() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCompany(i));
		}

		public string GetLastName() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetLastName(i));
		}

		public string GetAddress() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetAddress(i));
		}

		public string GetAddress2() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetAddress2(i));
		}

		public string GetSuite() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSuite(i));
		}

		public string GetCity() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCity(i));
		}

		public string GetCityAbbreviation() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCityAbbreviation(i));
		}

		public string GetState() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetState(i));
		}

		public string GetZip() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetZip(i));
		}

		public string GetPlus4() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetPlus4(i));
		}

		public string GetCarrierRoute() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCarrierRoute(i));
		}

		public string GetDeliveryPointCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDeliveryPointCode(i));
		}

		public string GetDeliveryPointCheckDigit() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDeliveryPointCheckDigit(i));
		}

		public string GetCountyFips() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCountyFips(i));
		}

		public string GetCountyName() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCountyName(i));
		}

		public string GetAddressTypeCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetAddressTypeCode(i));
		}

		public string GetAddressTypeString() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetAddressTypeString(i));
		}

		public string GetUrbanization() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetUrbanization(i));
		}

		public string GetCongressionalDistrict() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCongressionalDistrict(i));
		}

		public string GetLACS() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetLACS(i));
		}

		public string GetLACSLinkIndicator() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetLACSLinkIndicator(i));
		}

		public string GetPrivateMailbox() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetPrivateMailbox(i));
		}

		public string GetTimeZoneCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetTimeZoneCode(i));
		}

		public string GetTimeZone() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetTimeZone(i));
		}

		public string GetMsa() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetMsa(i));
		}

		public string GetPmsa() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetPmsa(i));
		}

		public string GetDefaultFlagIndicator() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDefaultFlagIndicator(i));
		}

		public string GetSuiteStatus() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSuiteStatus(i));
		}

		public string GetEWSFlag() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetEWSFlag(i));
		}

		public string GetCMRA() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCMRA(i));
		}

		public string GetDsfVacant() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDsfVacant(i));
		}

		public string GetCountryCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetCountryCode(i));
		}

		public string GetZipType() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetZipType(i));
		}

		public string GetFalseTable() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetFalseTable(i));
		}

		public string GetDPVFootnotes() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDPVFootnotes(i));
		}

		public string GetLACSLinkReturnCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetLACSLinkReturnCode(i));
		}

		public string GetSuiteLinkReturnCode() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetSuiteLinkReturnCode(i));
		}

		public string GetRBDI() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetRBDI(i));
		}

		public string GetELotNumber() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetELotNumber(i));
		}

		public string GetELotOrder() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetELotOrder(i));
		}

		public string GetAddressKey() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetAddressKey(i));
		}

		public string GetMelissaAddressKey() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetMelissaAddressKey(i));
		}

		public string GetMelissaAddressKeyBase() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetMelissaAddressKeyBase(i));
		}

		public string GetOutputParameter(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetOutputParameter(i, u_p1.GetPtr()));
		}

		public int SetInputParameter(string p1, string p2) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			return mdAddrUnmanaged.mdAddrSetInputParameter(i, u_p1.GetPtr(), u_p2.GetPtr());
		}

		public bool FindSuggestion() {
			return (mdAddrUnmanaged.mdAddrFindSuggestion(i) != 0);
		}

		public bool FindSuggestionNext() {
			return (mdAddrUnmanaged.mdAddrFindSuggestionNext(i) != 0);
		}

		public string GetDsfNoStats() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDsfNoStats(i));
		}

		public string GetDsfDNA() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetDsfDNA(i));
		}

		public int GetPS3553_B6_TotalRecords() {
			return mdAddrUnmanaged.mdAddrGetPS3553_B6_TotalRecords(i);
		}

		public int GetPS3553_C1a_ZIP4Coded() {
			return mdAddrUnmanaged.mdAddrGetPS3553_C1a_ZIP4Coded(i);
		}

		public int GetPS3553_C1c_DPBCAssigned() {
			return mdAddrUnmanaged.mdAddrGetPS3553_C1c_DPBCAssigned(i);
		}

		public int GetPS3553_C1d_FiveDigitCoded() {
			return mdAddrUnmanaged.mdAddrGetPS3553_C1d_FiveDigitCoded(i);
		}

		public int GetPS3553_C1e_CRRTCoded() {
			return mdAddrUnmanaged.mdAddrGetPS3553_C1e_CRRTCoded(i);
		}

		public int GetPS3553_C1f_eLOTAssigned() {
			return mdAddrUnmanaged.mdAddrGetPS3553_C1f_eLOTAssigned(i);
		}

		public int GetPS3553_E_HighRiseDefault() {
			return mdAddrUnmanaged.mdAddrGetPS3553_E_HighRiseDefault(i);
		}

		public int GetPS3553_E_HighRiseExact() {
			return mdAddrUnmanaged.mdAddrGetPS3553_E_HighRiseExact(i);
		}

		public int GetPS3553_E_RuralRouteDefault() {
			return mdAddrUnmanaged.mdAddrGetPS3553_E_RuralRouteDefault(i);
		}

		public int GetPS3553_E_RuralRouteExact() {
			return mdAddrUnmanaged.mdAddrGetPS3553_E_RuralRouteExact(i);
		}

		public int GetZip4HRDefault() {
			return mdAddrUnmanaged.mdAddrGetZip4HRDefault(i);
		}

		public int GetZip4HRExact() {
			return mdAddrUnmanaged.mdAddrGetZip4HRExact(i);
		}

		public int GetZip4RRDefault() {
			return mdAddrUnmanaged.mdAddrGetZip4RRDefault(i);
		}

		public int GetZip4RRExact() {
			return mdAddrUnmanaged.mdAddrGetZip4RRExact(i);
		}

		public int GetPS3553_E_LACSCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_E_LACSCount(i);
		}

		public int GetPS3553_E_EWSCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_E_EWSCount(i);
		}

		public int GetPS3553_E_DPVCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_E_DPVCount(i);
		}

		public int GetPS3553_X_POBoxCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_POBoxCount(i);
		}

		public int GetPS3553_X_HCExactCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_HCExactCount(i);
		}

		public int GetPS3553_X_FirmCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_FirmCount(i);
		}

		public int GetPS3553_X_GenDeliveryCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_GenDeliveryCount(i);
		}

		public int GetPS3553_X_MilitaryZipCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_MilitaryZipCount(i);
		}

		public int GetPS3553_X_NonDeliveryCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_NonDeliveryCount(i);
		}

		public int GetPS3553_X_StreetCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_StreetCount(i);
		}

		public int GetPS3553_X_HCDefaultCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_HCDefaultCount(i);
		}

		public int GetPS3553_X_OtherCount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_OtherCount(i);
		}

		public int GetPS3553_X_LacsLinkCodeACount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_LacsLinkCodeACount(i);
		}

		public int GetPS3553_X_LacsLinkCode00Count() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_LacsLinkCode00Count(i);
		}

		public int GetPS3553_X_LacsLinkCode14Count() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_LacsLinkCode14Count(i);
		}

		public int GetPS3553_X_LacsLinkCode92Count() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_LacsLinkCode92Count(i);
		}

		public int GetPS3553_X_LacsLinkCode09Count() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_LacsLinkCode09Count(i);
		}

		public int GetPS3553_X_SuiteLinkCodeACount() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_SuiteLinkCodeACount(i);
		}

		public int GetPS3553_X_SuiteLinkCode00Count() {
			return mdAddrUnmanaged.mdAddrGetPS3553_X_SuiteLinkCode00Count(i);
		}

		public string GetParsedAddressRange() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedAddressRange(i));
		}

		public string GetParsedPreDirection() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedPreDirection(i));
		}

		public string GetParsedStreetName() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedStreetName(i));
		}

		public string GetParsedSuffix() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedSuffix(i));
		}

		public string GetParsedPostDirection() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedPostDirection(i));
		}

		public string GetParsedSuiteName() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedSuiteName(i));
		}

		public string GetParsedSuiteRange() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedSuiteRange(i));
		}

		public string GetParsedPrivateMailboxName() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedPrivateMailboxName(i));
		}

		public string GetParsedPrivateMailboxNumber() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedPrivateMailboxNumber(i));
		}

		public string GetParsedGarbage() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedGarbage(i));
		}

		public string GetParsedRouteService() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedRouteService(i));
		}

		public string GetParsedLockBox() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedLockBox(i));
		}

		public string GetParsedDeliveryInstallation() {
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetParsedDeliveryInstallation(i));
		}

		public void SetReserved(string p1, string p2) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			mdAddrUnmanaged.mdAddrSetReserved(i, u_p1.GetPtr(), u_p2.GetPtr());
		}

		public string GetReserved(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return EncodedString.GetEncodedString(mdAddrUnmanaged.mdAddrGetReserved(i, u_p1.GetPtr()));
		}

		private class EncodedString : IDisposable {
			private IntPtr encodedString = IntPtr.Zero;
			private static Encoding encoding = Encoding.GetEncoding("ISO-8859-1");

			public EncodedString(string str) {
				if (str == null)
					str = "";
				byte[] buffer = encoding.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				encodedString = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, encodedString, buffer.Length);
			}

			~EncodedString() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(encodedString);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetPtr() {
				return encodedString;
			}

			public static string GetEncodedString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return encoding.GetString(buffer);
			}
		}
	}

	public class mdParse : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			ErrorNone = 0,
			ErrorOther = 1,
			ErrorOutOfMemory = 2,
			ErrorRequiredFileNotFound = 3,
			ErrorFoundOldFile = 4,
			ErrorDatabaseExpired = 5,
			ErrorLicenseExpired = 6
		}
		public enum AccessType {
			Local = 0,
			Remote = 1
		}
		public enum DiacriticsMode {
			Auto = 0,
			On = 1,
			Off = 2
		}
		public enum StandardizeMode {
			ShortFormat = 0,
			LongFormat = 1,
			AutoFormat = 2
		}
		public enum SuiteParseMode {
			ParseSuite = 0,
			CombineSuite = 1
		}
		public enum AliasPreserveMode {
			ConvertAlias = 0,
			PreserveAlias = 1
		}
		public enum AutoCompletionMode {
			AutoCompleteSingleSuite = 0,
			AutoCompleteRangedSuite = 1,
			AutoCompletePlaceHolderSuite = 2,
			AutoCompleteNoSuite = 3
		}
		public enum ResultCdDescOpt {
			ResultCodeDescriptionLong = 0,
			ResultCodeDescriptionShort = 1
		}
		public enum MailboxLookupMode {
			MailboxNone = 0,
			MailboxExpress = 1,
			MailboxPremium = 2
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdParseUnmanaged {
			[DllImport("mdAddr", EntryPoint = "mdParseCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseCreate();
			[DllImport("mdAddr", EntryPoint = "mdParseDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdParseDestroy(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseInitialize", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdParseInitialize(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdParseGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetBuildNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseParse", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdParseParse(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdParseParseCanadian", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdParseParseCanadian(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdParseParseNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdParseParseNext(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseLastLineParse", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdParseLastLineParse(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdParseGetZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetZip(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetPlus4", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetPlus4(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetCity(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetState(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetStreetName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetStreetName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetRange(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetPreDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetPreDirection(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetPostDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetPostDirection(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetSuffix", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetSuffix(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetSuiteName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetSuiteName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetSuiteNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetSuiteNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetPrivateMailboxNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetPrivateMailboxNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetPrivateMailboxName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetPrivateMailboxName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetGarbage", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetGarbage(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetRouteService", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetRouteService(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetLockBox", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetLockBox(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseGetDeliveryInstallation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdParseGetDeliveryInstallation(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdParseParseRule", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdParseParseRule(IntPtr i);
		}

		public mdParse() {
			i = mdParseUnmanaged.mdParseCreate();
		}

		~mdParse() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdParseUnmanaged.mdParseDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public ProgramStatus Initialize(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (ProgramStatus)mdParseUnmanaged.mdParseInitialize(i, u_p1.GetPtr());
		}

		public string GetBuildNumber() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetBuildNumber(i));
		}

		public void Parse(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdParseUnmanaged.mdParseParse(i, u_p1.GetPtr());
		}

		public void ParseCanadian(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdParseUnmanaged.mdParseParseCanadian(i, u_p1.GetPtr());
		}

		public bool ParseNext() {
			return (mdParseUnmanaged.mdParseParseNext(i) != 0);
		}

		public void LastLineParse(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdParseUnmanaged.mdParseLastLineParse(i, u_p1.GetPtr());
		}

		public string GetZip() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetZip(i));
		}

		public string GetPlus4() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetPlus4(i));
		}

		public string GetCity() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetCity(i));
		}

		public string GetState() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetState(i));
		}

		public string GetStreetName() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetStreetName(i));
		}

		public string GetRange() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetRange(i));
		}

		public string GetPreDirection() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetPreDirection(i));
		}

		public string GetPostDirection() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetPostDirection(i));
		}

		public string GetSuffix() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetSuffix(i));
		}

		public string GetSuiteName() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetSuiteName(i));
		}

		public string GetSuiteNumber() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetSuiteNumber(i));
		}

		public string GetPrivateMailboxNumber() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetPrivateMailboxNumber(i));
		}

		public string GetPrivateMailboxName() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetPrivateMailboxName(i));
		}

		public string GetGarbage() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetGarbage(i));
		}

		public string GetRouteService() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetRouteService(i));
		}

		public string GetLockBox() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetLockBox(i));
		}

		public string GetDeliveryInstallation() {
			return EncodedString.GetEncodedString(mdParseUnmanaged.mdParseGetDeliveryInstallation(i));
		}

		public int ParseRule() {
			return mdParseUnmanaged.mdParseParseRule(i);
		}

		private class EncodedString : IDisposable {
			private IntPtr encodedString = IntPtr.Zero;
			private static Encoding encoding = Encoding.GetEncoding("ISO-8859-1");

			public EncodedString(string str) {
				if (str == null)
					str = "";
				byte[] buffer = encoding.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				encodedString = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, encodedString, buffer.Length);
			}

			~EncodedString() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(encodedString);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetPtr() {
				return encodedString;
			}

			public static string GetEncodedString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return encoding.GetString(buffer);
			}
		}
	}

	public class mdStreet : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			ErrorNone = 0,
			ErrorOther = 1,
			ErrorOutOfMemory = 2,
			ErrorRequiredFileNotFound = 3,
			ErrorFoundOldFile = 4,
			ErrorDatabaseExpired = 5,
			ErrorLicenseExpired = 6
		}
		public enum AccessType {
			Local = 0,
			Remote = 1
		}
		public enum DiacriticsMode {
			Auto = 0,
			On = 1,
			Off = 2
		}
		public enum StandardizeMode {
			ShortFormat = 0,
			LongFormat = 1,
			AutoFormat = 2
		}
		public enum SuiteParseMode {
			ParseSuite = 0,
			CombineSuite = 1
		}
		public enum AliasPreserveMode {
			ConvertAlias = 0,
			PreserveAlias = 1
		}
		public enum AutoCompletionMode {
			AutoCompleteSingleSuite = 0,
			AutoCompleteRangedSuite = 1,
			AutoCompletePlaceHolderSuite = 2,
			AutoCompleteNoSuite = 3
		}
		public enum ResultCdDescOpt {
			ResultCodeDescriptionLong = 0,
			ResultCodeDescriptionShort = 1
		}
		public enum MailboxLookupMode {
			MailboxNone = 0,
			MailboxExpress = 1,
			MailboxPremium = 2
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdStreetUnmanaged {
			[DllImport("mdAddr", EntryPoint = "mdStreetCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetCreate();
			[DllImport("mdAddr", EntryPoint = "mdStreetDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdStreetDestroy(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetInitialize", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdStreetInitialize(IntPtr i, IntPtr p1, IntPtr p2, IntPtr p3);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetInitializeErrorString(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetDatabaseDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetBuildNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdStreetSetLicenseString(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetLicenseExpirationDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetFindStreet", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdStreetFindStreet(IntPtr i, IntPtr p1, IntPtr p2, Int32 p3);
			[DllImport("mdAddr", EntryPoint = "mdStreetFindStreetNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdStreetFindStreetNext(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetIsAddressInRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdStreetIsAddressInRange(IntPtr i, IntPtr p1, IntPtr p2, IntPtr p3);
			[DllImport("mdAddr", EntryPoint = "mdStreetIsAddressInRange2", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdStreetIsAddressInRange2(IntPtr i, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetAutoCompletion", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetAutoCompletion(IntPtr i, IntPtr p1, IntPtr p2, Int32 p3, Int32 p4);
			[DllImport("mdAddr", EntryPoint = "mdStreetResetAutoCompletion", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdStreetResetAutoCompletion(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetBaseAlternateIndicator", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetBaseAlternateIndicator(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetLACSIndicator", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetLACSIndicator(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetUrbanizationCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetUrbanizationCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetUrbanizationName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetUrbanizationName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetLastLineNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetLastLineNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetAddressType", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetAddressType(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetCongressionalDistrict", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetCongressionalDistrict(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetCountyFips", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetCountyFips(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetCompany(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetCarrierRoute", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetCarrierRoute(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetZip(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetDeliveryInstallation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetDeliveryInstallation(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetPlus4High", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetPlus4High(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetPlus4Low", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetPlus4Low(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetSuiteRangeOddEven", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetSuiteRangeOddEven(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetSuiteRangeHigh", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetSuiteRangeHigh(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetSuiteRangeLow", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetSuiteRangeLow(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetSuiteName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetSuiteName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetPostDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetPostDirection(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetSuffix", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetSuffix(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetStreetName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetStreetName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetPreDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetPreDirection(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetPrimaryRangeOddEven", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetPrimaryRangeOddEven(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetPrimaryRangeHigh", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetPrimaryRangeHigh(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdStreetGetPrimaryRangeLow", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdStreetGetPrimaryRangeLow(IntPtr i);
		}

		public mdStreet() {
			i = mdStreetUnmanaged.mdStreetCreate();
		}

		~mdStreet() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdStreetUnmanaged.mdStreetDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public ProgramStatus Initialize(string p1, string p2, string p3) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			EncodedString u_p3 = new EncodedString(p3);
			return (ProgramStatus)mdStreetUnmanaged.mdStreetInitialize(i, u_p1.GetPtr(), u_p2.GetPtr(), u_p3.GetPtr());
		}

		public string GetInitializeErrorString() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetInitializeErrorString(i));
		}

		public string GetDatabaseDate() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetDatabaseDate(i));
		}

		public string GetBuildNumber() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetBuildNumber(i));
		}

		public bool SetLicenseString(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdStreetUnmanaged.mdStreetSetLicenseString(i, u_p1.GetPtr()) != 0);
		}

		public string GetLicenseExpirationDate() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetLicenseExpirationDate(i));
		}

		public bool FindStreet(string p1, string p2, bool p3) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			return (mdStreetUnmanaged.mdStreetFindStreet(i, u_p1.GetPtr(), u_p2.GetPtr(), (p3 ? 1 : 0)) != 0);
		}

		public bool FindStreetNext() {
			return (mdStreetUnmanaged.mdStreetFindStreetNext(i) != 0);
		}

		public bool IsAddressInRange(string p1, string p2, string p3) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			EncodedString u_p3 = new EncodedString(p3);
			return (mdStreetUnmanaged.mdStreetIsAddressInRange(i, u_p1.GetPtr(), u_p2.GetPtr(), u_p3.GetPtr()) != 0);
		}

		public bool IsAddressInRange2(string p1, string p2, string p3, string p4) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			EncodedString u_p3 = new EncodedString(p3);
			EncodedString u_p4 = new EncodedString(p4);
			return (mdStreetUnmanaged.mdStreetIsAddressInRange2(i, u_p1.GetPtr(), u_p2.GetPtr(), u_p3.GetPtr(), u_p4.GetPtr()) != 0);
		}

		public string GetAutoCompletion(string p1, string p2, AutoCompletionMode p3, bool p4) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetAutoCompletion(i, u_p1.GetPtr(), u_p2.GetPtr(), (int)p3, (p4 ? 1 : 0)));
		}

		public void ResetAutoCompletion() {
			mdStreetUnmanaged.mdStreetResetAutoCompletion(i);
		}

		public string GetBaseAlternateIndicator() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetBaseAlternateIndicator(i));
		}

		public string GetLACSIndicator() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetLACSIndicator(i));
		}

		public string GetUrbanizationCode() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetUrbanizationCode(i));
		}

		public string GetUrbanizationName() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetUrbanizationName(i));
		}

		public string GetLastLineNumber() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetLastLineNumber(i));
		}

		public string GetAddressType() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetAddressType(i));
		}

		public string GetCongressionalDistrict() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetCongressionalDistrict(i));
		}

		public string GetCountyFips() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetCountyFips(i));
		}

		public string GetCompany() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetCompany(i));
		}

		public string GetCarrierRoute() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetCarrierRoute(i));
		}

		public string GetZip() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetZip(i));
		}

		public string GetDeliveryInstallation() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetDeliveryInstallation(i));
		}

		public string GetPlus4High() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetPlus4High(i));
		}

		public string GetPlus4Low() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetPlus4Low(i));
		}

		public string GetSuiteRangeOddEven() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetSuiteRangeOddEven(i));
		}

		public string GetSuiteRangeHigh() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetSuiteRangeHigh(i));
		}

		public string GetSuiteRangeLow() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetSuiteRangeLow(i));
		}

		public string GetSuiteName() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetSuiteName(i));
		}

		public string GetPostDirection() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetPostDirection(i));
		}

		public string GetSuffix() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetSuffix(i));
		}

		public string GetStreetName() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetStreetName(i));
		}

		public string GetPreDirection() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetPreDirection(i));
		}

		public string GetPrimaryRangeOddEven() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetPrimaryRangeOddEven(i));
		}

		public string GetPrimaryRangeHigh() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetPrimaryRangeHigh(i));
		}

		public string GetPrimaryRangeLow() {
			return EncodedString.GetEncodedString(mdStreetUnmanaged.mdStreetGetPrimaryRangeLow(i));
		}

		private class EncodedString : IDisposable {
			private IntPtr encodedString = IntPtr.Zero;
			private static Encoding encoding = Encoding.GetEncoding("ISO-8859-1");

			public EncodedString(string str) {
				if (str == null)
					str = "";
				byte[] buffer = encoding.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				encodedString = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, encodedString, buffer.Length);
			}

			~EncodedString() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(encodedString);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetPtr() {
				return encodedString;
			}

			public static string GetEncodedString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return encoding.GetString(buffer);
			}
		}
	}

	public class mdZip : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			ErrorNone = 0,
			ErrorOther = 1,
			ErrorOutOfMemory = 2,
			ErrorRequiredFileNotFound = 3,
			ErrorFoundOldFile = 4,
			ErrorDatabaseExpired = 5,
			ErrorLicenseExpired = 6
		}
		public enum AccessType {
			Local = 0,
			Remote = 1
		}
		public enum DiacriticsMode {
			Auto = 0,
			On = 1,
			Off = 2
		}
		public enum StandardizeMode {
			ShortFormat = 0,
			LongFormat = 1,
			AutoFormat = 2
		}
		public enum SuiteParseMode {
			ParseSuite = 0,
			CombineSuite = 1
		}
		public enum AliasPreserveMode {
			ConvertAlias = 0,
			PreserveAlias = 1
		}
		public enum AutoCompletionMode {
			AutoCompleteSingleSuite = 0,
			AutoCompleteRangedSuite = 1,
			AutoCompletePlaceHolderSuite = 2,
			AutoCompleteNoSuite = 3
		}
		public enum ResultCdDescOpt {
			ResultCodeDescriptionLong = 0,
			ResultCodeDescriptionShort = 1
		}
		public enum MailboxLookupMode {
			MailboxNone = 0,
			MailboxExpress = 1,
			MailboxPremium = 2
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdZipUnmanaged {
			[DllImport("mdAddr", EntryPoint = "mdZipCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipCreate();
			[DllImport("mdAddr", EntryPoint = "mdZipDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdZipDestroy(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipInitialize", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipInitialize(IntPtr i, IntPtr p1, IntPtr p2, IntPtr p3);
			[DllImport("mdAddr", EntryPoint = "mdZipGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetInitializeErrorString(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetDatabaseDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetBuildNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipSetLicenseString(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdZipGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetLicenseExpirationDate(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipFindZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipFindZip(IntPtr i, IntPtr p1, Int32 p2);
			[DllImport("mdAddr", EntryPoint = "mdZipFindZipNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipFindZipNext(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipFindZipInCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipFindZipInCity(IntPtr i, IntPtr p1, IntPtr p2);
			[DllImport("mdAddr", EntryPoint = "mdZipFindZipInCityNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipFindZipInCityNext(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipFindCityInState", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipFindCityInState(IntPtr i, IntPtr p1, IntPtr p2);
			[DllImport("mdAddr", EntryPoint = "mdZipFindCityInStateNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipFindCityInStateNext(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipComputeDistance", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdZipComputeDistance(IntPtr i, double p1, double p2, double p3, double p4);
			[DllImport("mdAddr", EntryPoint = "mdZipComputeBearing", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdZipComputeBearing(IntPtr i, double p1, double p2, double p3, double p4);
			[DllImport("mdAddr", EntryPoint = "mdZipGetCountyNameFromFips", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetCountyNameFromFips(IntPtr i, IntPtr p1);
			[DllImport("mdAddr", EntryPoint = "mdZipGetSCFArea", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdZipGetSCFArea(IntPtr i, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4, IntPtr p5);
			[DllImport("mdAddr", EntryPoint = "mdZipGetZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetZip(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetCity(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetCityAbbreviation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetCityAbbreviation(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetState(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetZipType", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetZipType(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetCountyName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetCountyName(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetCountyFips", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetCountyFips(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetAreaCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetAreaCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetLongitude", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetLongitude(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetLatitude", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetLatitude(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetTimeZone", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetTimeZone(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetTimeZoneCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetTimeZoneCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetMsa", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetMsa(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetPmsa", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetPmsa(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetFacilityCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetFacilityCode(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetLastLineIndicator", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetLastLineIndicator(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetLastLineNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetLastLineNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetPreferredLastLineNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetPreferredLastLineNumber(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetAutomation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetAutomation(IntPtr i);
			[DllImport("mdAddr", EntryPoint = "mdZipGetFinanceNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdZipGetFinanceNumber(IntPtr i);
		}

		public mdZip() {
			i = mdZipUnmanaged.mdZipCreate();
		}

		~mdZip() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdZipUnmanaged.mdZipDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public ProgramStatus Initialize(string p1, string p2, string p3) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			EncodedString u_p3 = new EncodedString(p3);
			return (ProgramStatus)mdZipUnmanaged.mdZipInitialize(i, u_p1.GetPtr(), u_p2.GetPtr(), u_p3.GetPtr());
		}

		public string GetInitializeErrorString() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetInitializeErrorString(i));
		}

		public string GetDatabaseDate() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetDatabaseDate(i));
		}

		public string GetBuildNumber() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetBuildNumber(i));
		}

		public bool SetLicenseString(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdZipUnmanaged.mdZipSetLicenseString(i, u_p1.GetPtr()) != 0);
		}

		public string GetLicenseExpirationDate() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetLicenseExpirationDate(i));
		}

		public bool FindZip(string p1, bool p2) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdZipUnmanaged.mdZipFindZip(i, u_p1.GetPtr(), (p2 ? 1 : 0)) != 0);
		}

		public bool FindZipNext() {
			return (mdZipUnmanaged.mdZipFindZipNext(i) != 0);
		}

		public bool FindZipInCity(string p1, string p2) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			return (mdZipUnmanaged.mdZipFindZipInCity(i, u_p1.GetPtr(), u_p2.GetPtr()) != 0);
		}

		public bool FindZipInCityNext() {
			return (mdZipUnmanaged.mdZipFindZipInCityNext(i) != 0);
		}

		public bool FindCityInState(string p1, string p2) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			return (mdZipUnmanaged.mdZipFindCityInState(i, u_p1.GetPtr(), u_p2.GetPtr()) != 0);
		}

		public bool FindCityInStateNext() {
			return (mdZipUnmanaged.mdZipFindCityInStateNext(i) != 0);
		}

		public double ComputeDistance(double p1, double p2, double p3, double p4) {
			return mdZipUnmanaged.mdZipComputeDistance(i, p1, p2, p3, p4);
		}

		public double ComputeBearing(double p1, double p2, double p3, double p4) {
			return mdZipUnmanaged.mdZipComputeBearing(i, p1, p2, p3, p4);
		}

		public string GetCountyNameFromFips(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetCountyNameFromFips(i, u_p1.GetPtr()));
		}

		public int GetSCFArea(string p1, IntPtr p2, IntPtr p3, IntPtr p4, IntPtr p5) {
			EncodedString u_p1 = new EncodedString(p1);
			return mdZipUnmanaged.mdZipGetSCFArea(i, u_p1.GetPtr(), p2, p3, p4, p5);
		}

		public string GetZip() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetZip(i));
		}

		public string GetCity() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetCity(i));
		}

		public string GetCityAbbreviation() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetCityAbbreviation(i));
		}

		public string GetState() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetState(i));
		}

		public string GetZipType() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetZipType(i));
		}

		public string GetCountyName() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetCountyName(i));
		}

		public string GetCountyFips() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetCountyFips(i));
		}

		public string GetAreaCode() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetAreaCode(i));
		}

		public string GetLongitude() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetLongitude(i));
		}

		public string GetLatitude() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetLatitude(i));
		}

		public string GetTimeZone() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetTimeZone(i));
		}

		public string GetTimeZoneCode() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetTimeZoneCode(i));
		}

		public string GetMsa() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetMsa(i));
		}

		public string GetPmsa() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetPmsa(i));
		}

		public string GetFacilityCode() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetFacilityCode(i));
		}

		public string GetLastLineIndicator() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetLastLineIndicator(i));
		}

		public string GetLastLineNumber() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetLastLineNumber(i));
		}

		public string GetPreferredLastLineNumber() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetPreferredLastLineNumber(i));
		}

		public string GetAutomation() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetAutomation(i));
		}

		public string GetFinanceNumber() {
			return EncodedString.GetEncodedString(mdZipUnmanaged.mdZipGetFinanceNumber(i));
		}

		private class EncodedString : IDisposable {
			private IntPtr encodedString = IntPtr.Zero;
			private static Encoding encoding = Encoding.GetEncoding("ISO-8859-1");

			public EncodedString(string str) {
				if (str == null)
					str = "";
				byte[] buffer = encoding.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				encodedString = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, encodedString, buffer.Length);
			}

			~EncodedString() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(encodedString);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetPtr() {
				return encodedString;
			}

			public static string GetEncodedString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return encoding.GetString(buffer);
			}
		}
	}
}
