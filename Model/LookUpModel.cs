﻿using Ascon.Pilot.SDK;
using PilotLookUp.Commands;
using PilotLookUp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Windows;
using IDataObject = Ascon.Pilot.SDK.IDataObject;

namespace PilotLookUp.Model
{
    internal class LookUpModel
    {
        private List<PilotTypsHelper> _dataObjects { get; }
        private IObjectsRepository _objectsRepository { get; }


        public LookUpModel(List<PilotTypsHelper> dataObjects, IObjectsRepository objectsRepository)
        {
            _dataObjects = dataObjects;
            _objectsRepository = objectsRepository;
            PilotTypsHelper.Loader = new ObjectLoader(_objectsRepository);
        }

        public List<PilotTypsHelper> SelectionDataObjects => _dataObjects;

        public ObjReflection GetInfo(PilotTypsHelper dataObject)
        {
            return new ObjReflection(dataObject);
        }

        public async Task DataGridSelecror(object obj)
        {
            var loader = new ObjectLoader(_objectsRepository);

            if (obj == null) return;

            else if (obj is Guid id)
            {
                IDataObject dataObj = await loader.Load(id);
                if (dataObj != null)
                {
                    new RiseCommand(new LookSeleсtion(new List<PilotTypsHelper>() { new PilotTypsHelper(dataObj) }, _objectsRepository));
                }
            }

            else if (obj is IEnumerable<Guid> idEnum)
            {
                var dataObjes = new List<object>();
                foreach (var guid in idEnum)
                {
                    object dataObj = await loader.Load(guid);

                    if (dataObj != null)
                    {
                        dataObjes.Add(dataObj);
                    }
                }
                new RiseCommand(new LookSeleсtion(dataObjes.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is string str)
            {

            }

            else if (obj is DateTime date)
            {

            }

            else if (obj is bool boolVol)
            {

            }

            else if (obj is IDictionary<string, object> attrDict)
            {
                new RiseCommand(new LookSeleсtion(attrDict.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is IDictionary<Guid, int> childretTypes)
            {
                new RiseCommand(new LookSeleсtion(childretTypes.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is IType type)
            {
                new RiseCommand(new LookSeleсtion(new List<PilotTypsHelper>() { new PilotTypsHelper(type) }, _objectsRepository));
            }

            else if (obj is IPerson person)
            {
                new RiseCommand(new LookSeleсtion(new List<PilotTypsHelper>() { new PilotTypsHelper(person) }, _objectsRepository));
            }

            else if (obj is IEnumerable<IRelation> relEnum)
            {
                new RiseCommand(new LookSeleсtion(relEnum.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is IEnumerable<IAttribute> attrClassList)
            {
                new RiseCommand(new LookSeleсtion(attrClassList.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is IEnumerable<IFile> file)
            {
                new RiseCommand(new LookSeleсtion(file.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is IDictionary<int,IAccess> accessDict)
            {
                new RiseCommand(new LookSeleсtion(accessDict.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is IEnumerable<IAccessRecord> accessRecordList)
            {
                new RiseCommand(new LookSeleсtion(accessRecordList.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj is IFilesSnapshot filesSnapshot)
            {
                new RiseCommand(new LookSeleсtion(new List<PilotTypsHelper>() { new PilotTypsHelper(filesSnapshot) }, _objectsRepository));
            }

            else if (obj is IEnumerable<IFilesSnapshot> filesSnapshotList)
            {
                new RiseCommand(new LookSeleсtion(filesSnapshotList.Select(i => new PilotTypsHelper(i)).ToList(), _objectsRepository));
            }

            else if (obj.GetType().IsEnum)
            {
                var dataEnum = obj as Enum;
                new RiseCommand(new LookSeleсtion(new List<PilotTypsHelper>() { new PilotTypsHelper(dataEnum) }, _objectsRepository));
            }

 

            else
            {
                MessageBox.Show(obj.GetType().ToString());
            }
        }
    }
}