﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JTK.ArduinoArcade {
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    class RelayCommand : ICommand {
        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action mAction;

        #endregion

        #region Public Events

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action) {
            mAction = action;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Excutes the commands Action
        /// </summary>
        public void Execute(object parameter) {
            mAction?.Invoke();
        }

        #endregion
    }
}
