using System;
using System.Collections.Generic;

namespace ObjecPool
{
    public class PoolBase<T>
    {
        #region fields
        private readonly Func<T> _preloadFunc;
        private readonly Action<T> _getAction;
        private readonly Action<T> _returnAction;
        private Queue<T> _pool = new();
        private List<T> _active = new();
        #endregion

        #region constructor
        public PoolBase(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
        {
            if (preloadFunc == null)
            {
                return;
            }

            _preloadFunc = preloadFunc;
            _getAction = getAction;
            _returnAction = returnAction;

            for (int i = 0; i < preloadCount; i++)
            {
               Return(preloadFunc());
            }
        }
        #endregion

        #region public method
        public T Get()
        {  
            T item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();    
            _getAction(item);
            _active.Add(item);
            return item;
        }

        public void Return(T item)
        {
            _returnAction(item);
            _pool.Enqueue(item);
            _active.Remove(item);
        }

        public void ReturnAll()
        {
            foreach (T item in _active.ToArray())
            {    
                Return(item);
            }
        }
        #endregion
    }
}