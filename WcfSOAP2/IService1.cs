using AppsService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSOAP2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        [OperationContract]
        List<UserDTO> GetUser();
        [OperationContract]
        UserDTO GetUsertById(int id);

        [OperationContract]
        string Edit(int id, UserDTO userDTO);

        [OperationContract]
        string EditSong(int id, SongDTO songDTO);


        [OperationContract]
        string EditPlaylist(int id, PlayListDTO playListDTO);


        [OperationContract]
        string PostUser(UserDTO userDTO);

        [OperationContract]
        string EditUser(int id,UserDTO userDTO);

        [OperationContract]
        string DeleteUser(int id);

        [OperationContract]
        List<PlayListDTO> GetSPlayList();

        [OperationContract]
        PlayListDTO GetPlaylistById(int id);

        [OperationContract]
        string PostPlayList(PlayListDTO playListDTO);

        [OperationContract]
        string DeletePlayList(int id);
        [OperationContract]
        List<SongDTO> GetSSongist();

        [OperationContract]
        SongDTO GetSongById(int id);

        [OperationContract]
        string PostSong(SongDTO songDTO);

        [OperationContract]
        string DeleteSong(int id);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfSOAP2.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
