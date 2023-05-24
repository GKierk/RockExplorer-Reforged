namespace RockExplorer_Reforged.Interfaces
{
    public interface ICRUD<T>
    {
        public void Create (T entity);

        public T Read(int key);

        public Dictionary<int, T> ReadAll();

        public void Update(int key, T entity);

        public void Delete(int key);
    }
}
