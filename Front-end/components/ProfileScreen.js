import React, { useState } from 'react';
import { View, Text, StyleSheet, TouchableOpacity } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';

// Suponha que você tenha uma variável de estado para armazenar os dados do usuário
const usuario = {
  nome: 'John Doe',
  email: 'johndoe@example.com',
  idade: 30,
  cidade: 'New York',
  foto: null, // Suponha que a foto ainda não esteja disponível
};

const ProfileScreen = () => {
  // Estado para armazenar as postagens do usuário
  const [postagens, setPostagens] = useState([]);

  // Função para adicionar uma nova postagem
  const adicionarPostagem = (titulo) => {
    const novaPostagem = { titulo };
    setPostagens([...postagens, novaPostagem]);
    console.log('Postagem adicionada:', novaPostagem);
  };

  // Função para navegar para o feed e exibir a postagem completa
  const navigateToFeed = (postagem) => {
    // Navegar para o feed e passar a postagem completa
    // Você precisará implementar isso usando a navegação fornecida pelo React Navigation
    // Exemplo: navigation.navigate('Feed', { screen: 'DetalhesPostagem', params: { postagem: postagem } });
    console.log('Postagem clicada:', postagem);
  };

  return (
    <View style={styles.container}>
      <View style={styles.topContainer}>
        <View style={styles.photoContainer}>
          {usuario.foto ? ( // Verifica se a foto do usuário está disponível
            <Image source={{ uri: usuario.foto }} style={styles.photo} /> // Se estiver, mostra a foto
          ) : (
            <MaterialIcons name="account-circle" size={100} color="#FFFFFF" /> // Se não, mostra o ícone de foto
          )}
        </View>
        <View style={styles.infoContainer}>
          <View style={styles.infoRow}>
            <Text style={styles.label}>Nome:</Text>
            <Text style={styles.info}>{usuario.nome}</Text>
          </View>
          <View style={styles.infoRow}>
            <Text style={styles.label}>Idade:</Text>
            <Text style={styles.info}>{usuario.idade} anos</Text>
          </View>
          <Text style={styles.label}>Email:</Text>
          <Text style={styles.info}>{usuario.email}</Text>
          <Text style={styles.label}>Cidade:</Text>
          <Text style={styles.info}>{usuario.cidade}</Text>
        </View>
      </View>
      <View style={styles.bottomContainer}>
        {/* Renderize as postagens do usuário como títulos clicáveis */}
        {postagens.map((postagem, index) => (
          <TouchableOpacity key={index} onPress={() => navigateToFeed(postagem)}>
            <Text style={styles.postagem}>{postagem.titulo}</Text>
          </TouchableOpacity>
        ))}
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#77BECF',
    padding: 20,
  },
  topContainer: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  photoContainer: {
    marginRight: 20,
  },
  photo: {
    width: 100,
    height: 100,
    borderRadius: 50,
  },
  infoContainer: {
    flex: 1,
  },
  infoRow: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 4, // Adicionei um espaçamento inferior
  },
  label: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#FFFFFF',
    marginRight: 4, // Adicionei um espaçamento à direita
  },
  info: {
    fontSize: 16,
    color: '#FFFFFF',
  },
  bottomContainer: {
    flex: 1,
    backgroundColor: '#FFFFFF',
    borderTopLeftRadius: 20,
    borderTopRightRadius: 20,
    justifyContent: 'center',
    alignItems: 'center',
    padding: 20,
  },
  postagem: {
    fontSize: 18,
    marginBottom: 10,
  },
});

export default ProfileScreen;
