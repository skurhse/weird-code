namespace Xor;

public static class Xor
{
    public static int[] Decode(int[] encoded, int first)
    {
        var arr = new int[encoded.Length + 1];
        arr[0] = first;

        for (int i = 1; i < arr.Length; i++)
        {
            first = arr[i] = encoded[i - 1] ^ first;
        }

        return arr;
    }

    public static int[] DecodeWithSpans(int[] encoded, int first)
    {
        var arr = new int[encoded.Length + 1];
        arr[0] = first;

        var encodedSpan = encoded.AsSpan();
        var arrSpan = arr.AsSpan(1);
        for (int i = 0; i < arrSpan.Length; i++)
        {
            first = arrSpan[i] = encodedSpan[i] ^ first;
        }

        return arr;
    }

    public static int[] DecodeWithCopyAndSpan(int[] encoded, int first)
    {
        var intSize = sizeof(int);
        var arr = new int[encoded.Length + 1];
        arr[0] = first;
        System.Buffer.BlockCopy(encoded, 0, arr, intSize, intSize * encoded.Length);
        
        var arrSpan = arr.AsSpan(1);
        for (int i = 0; i < arrSpan.Length; i++)
        {
            arr[i+1] ^= arr[i];
        }

        return arr;
    }
}
