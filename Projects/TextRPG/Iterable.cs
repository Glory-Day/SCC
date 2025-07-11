namespace TextRPG
{
    public interface Iterable
    {
        /// <param name="key"></param>
        /// <returns></returns>
        Iterable GetNextIterator(int key);

        /// <summary>
        /// A list of iterators stored as one-to-one correspondences to keys.
        /// </summary>
        Iterable[] Iterators { get; }
    }
}