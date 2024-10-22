using static System.Windows.Forms.CheckedListBox;

public static class CheckedIndexCollectionExtentions
{
	public static int[] ToArray(this CheckedIndexCollection indexes)
	{
		int[] result = new int[indexes.Count];
		indexes.CopyTo(result, 0);

		return result;
	}
}