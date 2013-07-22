using System;
using System.Collections.Generic;

namespace FOnline
{
    public class GameTypeEventArgs : EventArgs
    {
        public Type Type { get; private set; }
        public Action<object> Callback { get; private set; }

        public GameTypeEventArgs (Type type, Action<object> callback)
        {
            this.Type = type;
            this.Callback = callback;
        }
    }
    /// <summary>
    /// Interface for native types that allow to handle associated
    /// gameplay types via special event handler
    /// </summary>
    public interface IGameTypeHandling
    {
        /// <summary>
        /// Returns disposable reference to a handler that it attached to game type handling event
        /// </summary>
        IDisposable HandleGameType (EventHandler<GameTypeEventArgs> h);
        /// <summary>
        /// Invokes the game type handling event.
        /// </summary>
        void InvokeGameTypeHandle (object sender, GameTypeEventArgs e);
    }

    /// <summary>
    /// Base class for gameplay types
    /// </summary>
    public abstract class GameType : IDisposable
    {
        List<IDisposable> eventHandlers = new List<IDisposable>();

        public void When(IDisposable handler)
        {
            eventHandlers.Add (handler);
        }
        public void HandleGameType(IGameTypeHandling engineObject)
        {
            eventHandlers.Add (engineObject.HandleGameType ((o,e) => 
            {
                if (e.Type == this.GetType())
                    e.Callback (this); 
            }));
        }
        public void InteractWith<T>(IGameTypeHandling native, Action<T> callback) where T: class
        {
            native.InvokeGameTypeHandle(native, new GameTypeEventArgs(typeof(T), o => callback(o as T)));
        }

        public void Dispose()
        {
            eventHandlers.ForEach (h => h.Dispose ());
        }
    }

    /// <summary>
    /// Wraps the callback to make possible to dispose an attached event handler
    /// </summary>
    public class DisposableEventHandler : IDisposable
    {
        Action dispose;
        bool disposed = false;
        public DisposableEventHandler(Action dispose)
        {
            this.dispose = dispose;
        }

        public void Dispose()
        {
            dispose ();
            disposed = true;
        }

        ~DisposableEventHandler()
        {
            if (!disposed)
                dispose ();
        }
    }
}

