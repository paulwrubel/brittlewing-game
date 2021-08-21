public static class EnumUtils
{

    public static TEnum TryParse<TEnum>(string v) where TEnum : struct
    {
        TEnum res;
        if (System.Enum.TryParse<TEnum>(v, out res))
        {
            return res;
        }
        throw new System.Exception(string.Format("could not parse enum value {0} as {1}", v, typeof(TEnum)));
    }

}