namespace Undersoft.Exercise
{
    public static class Palindrome
    {
        public static string Create(string str, int maxToRemove = 2, int minLength = 3)
        {
            return Combine(str, maxToRemove, minLength);
        }

        internal static unsafe bool IsValid(char* strp, int length)
        {
            for (int k = 0; k < length / 2; k++)
            {
                if (*(strp + k) != *(strp + length - 1 - k))
                    return false;
            }
            return true;
        }

        internal static unsafe string Combine(string str, int maxToRemove, int minLength)
        {
            fixed (char* strp = str)
            {
                int length = str.Length;
                char* variantp = stackalloc char[length];

                for (int i = 0; i < maxToRemove + 1; i++)
                {
                    int subLength = length - i;
                    int combinationCount = (i != 0) ? subLength + 1 : 1;

                    if (subLength < minLength)
                        break;

                    if (combinationCount == 1 && IsValid(strp, length))
                        return str;

                    for (int j = 0; j < combinationCount; j++)
                    {
                        int counter = 0;
                        for (int t = 0; t < length; t++)
                        {
                            if (t != j && t != j + i - 1)
                                *(variantp + counter++) = *(strp + t);
                        }

                        if (IsValid(variantp, subLength))
                            return new string(variantp, 0, subLength);
                    }
                }
                return "not possible";
            }
        }
    }
}