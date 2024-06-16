import React, { useState } from 'react';
import { View, Text, TextInput, Button, StyleSheet, Image, TouchableOpacity } from 'react-native';
import * as ImagePicker from 'expo-image-picker';
import { MaterialIcons } from '@expo/vector-icons';

const Postagens = ({ onNovaPostagem }) => {
  const [titulo, setTitulo] = useState('');
  const [descricao, setDescricao] = useState('');
  const [imagem, setImagem] = useState(null);
  const [tituloErro, setTituloErro] = useState('');
  const [descricaoErro, setDescricaoErro] = useState('');

  const handleCriarPostagem = () => {
    if (!titulo) {
      setTituloErro('Por favor, preencha o título.');
      return;
    } else {
      setTituloErro('');
    }

    if (!descricao) {
      setDescricaoErro('Por favor, preencha a descrição.');
      return;
    } else {
      setDescricaoErro('');
    }

    const novaPostagem = { titulo, descricao, imagem };
    onNovaPostagem(novaPostagem);
    setTitulo('');
    setDescricao('');
    setImagem(null);
  };

  const handleEscolherImagem = async () => {
    let result = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.Images,
      allowsEditing: true,
      aspect: [1, 1],
      quality: 1,
    });

    if (!result.cancelled) {
      setImagem(result.uri);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.titulo}>Nova Postagem</Text>
      <View style={styles.inputContainer}>
        <MaterialIcons name="title" size={24} color="black" style={styles.icon} />
        <TextInput
          style={styles.input}
          placeholder="Título"
          value={titulo}
          onChangeText={(text) => {
            setTitulo(text);
            setTituloErro('');
          }}
        />
        {tituloErro ? <Text style={styles.erro}>{tituloErro}</Text> : null}
      </View>
      <View style={styles.inputContainer}>
        <MaterialIcons name="description" size={24} color="black" style={styles.icon} />
        <TextInput
          style={[styles.input, { height: 100 }]}
          placeholder="Descrição"
          value={descricao}
          onChangeText={(text) => {
            setDescricao(text);
            setDescricaoErro('');
          }}
          multiline={true}
        />
        {descricaoErro ? <Text style={styles.erro}>{descricaoErro}</Text> : null}
      </View>
      <TouchableOpacity onPress={handleEscolherImagem}>
      <Text style={styles.selecionarImagem}>Selecione a Imagem</Text>
        <View style={styles.imagemContainer}>
          
          {!imagem && <MaterialIcons name="add-a-photo" size={40} color="black" />}
          {imagem && <Image source={{ uri: imagem }} style={styles.imagem} />}
        </View>
        
      </TouchableOpacity>
      <TouchableOpacity style={styles.botao} onPress={handleCriarPostagem}>
        <Text style={styles.textoBotao}>Criar Postagem</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: 'center',
    marginBottom: 20,
  },
  titulo: {
    fontSize: 20,
    fontWeight: 'bold',
    marginBottom: 10,
  },
  inputContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    width: '80%',
    backgroundColor: '#FFFFFF',
    borderRadius: 20,
    marginBottom: 10,
  },
  icon: {
    marginHorizontal: 10,
  },
  input: {
    flex: 1,
    borderWidth: 0,
    padding: 10,
    borderRadius: 20,
  },
  imagemContainer: {
    width: 150,
    height: 150,
    backgroundColor: '#FFFFFF',
    borderRadius: 75,
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 10,
    overflow: 'hidden',
    borderWidth: 2,
    borderColor: '#DDDDDD',
  },
  imagem: {
    width: '100%',
    height: '100%',
  },
  selecionarImagem: {
    fontSize: 16,
    color: 'black',
  },
  botao: {
    backgroundColor: '#77BECF',
    borderRadius: 20,
    padding: 10,
  },
  textoBotao: {
    color: 'white',
    textAlign: 'center',
  },
  erro: {
    color: 'red',
    fontSize: 12,
    marginTop: 2,
  },
});

export default Postagens;
