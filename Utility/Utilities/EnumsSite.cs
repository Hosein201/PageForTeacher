using System.ComponentModel.DataAnnotations;

namespace Utility.Utilities
{
    public enum GenderType
    {
        [Display(Name = "مرد")]
        Male = 1,

        [Display(Name = "زن")]
        Female = 2
    }
    public enum ImgFormat
    {
        bmp,
        jpg,
        jpeg,
        gif,
        tiff,
        png,
        unknown
    }
    public enum ApiResultStatusCode
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 0,

        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError = 1,

        [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
        BadRequest = 2,

        [Display(Name = "یافت نشد")]
        NotFound = 3,

        [Display(Name = "لیست خالی است")]
        ListEmpty = 4,

        [Display(Name = "خطایی در پردازش رخ داد")]
        LogicError = 5,

        [Display(Name = "خطای احراز هویت")]
        UnAuthorized = 6,

        [Display(Name = "کاربر در سیستم ثبت شده است")]
        UserIsInsystem = 7,

        [Display(Name = "عملیات با موفقیت انجام نشد")]
        NotSuccess = 8,

        [Display(Name = "کاربر مورد نظر یافت نشد")]
        NotFoundUser = 9,

        [Display(Name = "نام کاربری یا رمز عبور اشتباه است")]
        CheckPassword = 10,
    }

    public enum EnumResDelivery
    {
        [Display(Name = "ارسال به مخابرات")]
        SendToTelecommunications = 0,

        [Display(Name = "رسیده به گوشی ")]
        ReceiveToPhon = 1,

        [Display(Name = "نرسیده به گوشی ")]
        ReceiveDontToPhon = 2,

        [Display(Name = "خطا مخابراتی")]
        ErrorTelecommunications = 3,

        [Display(Name = "خطا نا مشخص")]
        ErrorUnknown = 5,

        [Display(Name = "ارسال به مخابرات")]
        ReceiveToTelecommunications = 8,

        [Display(Name = "نرسیده به مخابرات")]
        ReceiveDontToTelecommunications = 16,

        [Display(Name = "لیست خطا")]
        BlackList = 35,

        [Display(Name = "نامشخص")]
        Unknown = 100,

        [Display(Name = "ارسال شده")]
        Sended = 200,

        [Display(Name = "فیلتر شده")]
        Filter = 300,

        [Display(Name = "درلیست ارسال")]
        SendList = 400,

        [Display(Name = "عدم پذیرش از سمت اپراتور")]
        UnknownTelecommunications = 500,
    }

    public enum EnumResSendSms
    {

        [Display(Name = "نام کاربری و رمز عبور اشتباه می باشد")]
        UserUnAuthenticated = 0,

        [Display(Name = "درخواست با موفقیت انجام شد")]
        Ok = 1,

        [Display(Name = "اعتبار کافی نمی باشد")]
        LowCredit = 2,

        [Display(Name = "محدودیت در ارسال روزانه")]
        LimitDaily = 3,

        [Display(Name = "محدودیت در ارسال حجم")]
        LimitVolume = 4,

        [Display(Name = "محدودیت در ارسال حجم")]
        NumberPhonUnknown = 5,

        [Display(Name = "سامانه در حال بروز رسانی می باشد")]
        PanelIsUpdate = 6,

        [Display(Name = "متن حاوی کلمات فیلتر شده است")]
        WordIsFilter = 7,
    }

    public enum ConnectType
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
        HEAD = 4,
        OPTIONS = 5,
        PATCH = 6,
        MERGE = 7,
        COPY = 8
    }

    public enum TypeSmsApiPanel
    {
        SendSMS = 0,
        GetDeliveries2 = 1
    }

    public enum ImageFormat
    {
        bmp,
        jpg,
        jpeg,
        gif,
        tiff,
        png,
        unknown
    }
    public enum Gateway
    {
        Mellat = 0,
        Melli = 1,
        Saman = 2,
        Parsian = 3,
        Pasargad = 4,
        IranKish = 5,
        ZarinPal = 6,
        PayIr = 7,
        IdPay = 8,
        ParbadVirtual = 9,
    }
    public enum Roles
    {
        /// <summary>
        /// Admin
        /// </summary>
        [Display(Name = "Admin")]
        Admin = 1,
        /// <summary>
        /// دانشجو
        /// </summary>
        [Display(Name = "Staudent")]
        Staudent = 2,
        /// <summary>
        /// استاد
        /// </summary>
        [Display(Name = "Teacher")]
        Teacher = 3,
        /// <summary>
        /// پشتیبان
        /// </summary>
        [Display(Name = "Support")]
        Support = 4
    }

    public enum SupportExchangesState
    {
        [Display(Name = "درحال بررسی فایل")]
        ConfirmeingFile = 0,

        [Display(Name = "درحال انجام")]
        Doing = 1,

        [Display(Name = "رد شده توسط کاربر")]
        CancelByUser = 2,

        [Display(Name = "رد شده توسط مدیر")]
        CancelByAdmin = 3,

        [Display(Name = "تایید نهایی")]
        Done = 4,
    }

    public enum VencoinCondition
    {
        [Display(Name = "اکنون")]
        Now = 0,
        [Display(Name = "یک روز")]
        OneDay = 1,
        [Display(Name = "دو روز")]
        TwoDay = 2,
        [Display(Name = "سه روز")]
        ThreeDay = 3,
        [Display(Name = "چهار روز")]
        FourDay = 4,
        [Display(Name = "پنج روز")]
        FiveDay = 5,
        [Display(Name = "شش روز")]
        SixDay = 6,
        [Display(Name = "هفت روز")]
        SevenDay = 7,
        [Display(Name = "صف انتظار")]
        WaitingLine = 8,
    }

    public enum VencoinTypeSaleOrBuy
    {
        [Display(Name = "فروش")]
        Sale = 0,
        [Display(Name = "خرید")]
        Buy = 1,
    }

    public enum TypeImgUser
    {
        [Display(Name = "مدرک تحصیلی")]
        Education = 0,
        [Display(Name = "پرسنلی")]
        Personnel = 1,
        [Display(Name = "فارغ تحصیلی")]
        EndEducation = 2,
    }
}

