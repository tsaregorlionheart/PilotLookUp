﻿using Ascon.Pilot.SDK;
using PilotLookUp.Objects;
using PilotLookUp.View;
using PilotLookUp.VM;
using System.Collections.Generic;


namespace PilotLookUp.Model
{
    internal class LookSeleсtion
    {
        private List<PilotObjectHelper> _dataObject { get; }
        private IObjectsRepository _objectsRepository { get; }

        internal LookSeleсtion(List<PilotObjectHelper> dataObject, IObjectsRepository objectsRepository)
        {
            _dataObject = dataObject;
            _objectsRepository = objectsRepository;
            LookUpView view = new LookUpView(new LookUpVM(new LookUpModel(_dataObject, _objectsRepository)));
            view.Show();
        }
    }
}
