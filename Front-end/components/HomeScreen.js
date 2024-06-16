import React, { useState } from 'react';
import { View, Text, StyleSheet, Image, TouchableOpacity, TextInput } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Icon from 'react-native-vector-icons/Ionicons';
import Postagens from './Postagens';
import ProfileScreen from './ProfileScreen'; // Importe o componente ProfileScreen

const Tab = createBottomTabNavigator();

const HomeScreen = () => {
  // Estado para armazenar as postagens
  const [postagens, setPostagens] = useState([]);

  // Função para adicionar uma nova postagem à lista de postagens
  const adicionarPostagem = (novaPostagem) => {
    const dataHoraAtual = new Date().toLocaleString();
    setPostagens([...postagens, { ...novaPostagem, likes: 0, deslikes: 0, data: dataHoraAtual, comentarios: [] }]);
  };

  // Função para aumentar o contador de likes
  const adicionarLike = (index) => {
    const novasPostagens = [...postagens];
    novasPostagens[index].likes += 1;
    setPostagens(novasPostagens);
  };

  // Função para aumentar o contador de deslikes
  const adicionarDeslike = (index) => {
    const novasPostagens = [...postagens];
    novasPostagens[index].deslikes += 1;
    setPostagens(novasPostagens);
  };

  // Função para adicionar um comentário à postagem
  const adicionarComentario = (index, autor, texto) => {
    const novasPostagens = [...postagens];
    novasPostagens[index].comentarios.push({ autor, texto });
    setPostagens(novasPostagens);
  };

  return (
    <Tab.Navigator>
      <Tab.Screen
        name="Feed"
        options={{
          tabBarLabel: 'Feed',
          tabBarIcon: ({ color, size }) => (
            <Icon name="home" color={color} size={size} />
          ),
        }}
      >
        {() => <HomeTab postagens={postagens} adicionarLike={adicionarLike} adicionarDeslike={adicionarDeslike} adicionarComentario={adicionarComentario} />}
      </Tab.Screen>
      <Tab.Screen
        name="Postagens"
        options={{
          tabBarLabel: 'Postagens',
          tabBarIcon: ({ color, size }) => (
            <Icon name="add-circle-outline" color={color} size={size} />
          ),
        }}
      >
        {() => <Postagens onNovaPostagem={adicionarPostagem} />}
      </Tab.Screen>
      <Tab.Screen
        name="Profile"
        component={ProfileScreen}
        options={{
          tabBarLabel: 'Profile',
          tabBarIcon: ({ color, size }) => (
            <Icon name="person" color={color} size={size} />
          ),
        }}
      />
    </Tab.Navigator>
  );
};

const HomeTab = ({ postagens, adicionarLike, adicionarDeslike, adicionarComentario }) => {
  // Estado para controlar se o usuário já deu like ou deslike em uma postagem
  const [interacaoUsuario, setInteracaoUsuario] = useState({});
  // Estado para controlar a exibição dos comentários
  const [mostrarComentarios, setMostrarComentarios] = useState({});

  // Estado para armazenar o texto do novo comentário
  const [novoComentario, setNovoComentario] = useState('');

  // Função para lidar com o like ou deslike do usuário
  const handleInteracao = (index, tipo) => {
    // Verifica se o usuário já interagiu com essa postagem
    if (interacaoUsuario[index]) {
      return; // Se já interagiu, sai da função
    }
    // Atualiza o estado da interação do usuário
    setInteracaoUsuario({ ...interacaoUsuario, [index]: true });
    // Adiciona o like ou deslike conforme o tipo
    tipo === 'like' ? adicionarLike(index) : adicionarDeslike(index);
  };

  // Função para alternar a visibilidade dos comentários
  const toggleComentarios = (index) => {
    setMostrarComentarios({ ...mostrarComentarios, [index]: !mostrarComentarios[index] });
  };

  // Função para enviar o novo comentário
  const enviarComentario = (index) => {
    if (novoComentario.trim() !== '') {
      adicionarComentario(index, 'Eu', novoComentario);
      setNovoComentario(''); // Limpa o campo de texto do comentário após enviar
    }
  };

  return (
    <View style={{ flex: 1, padding: 16 }}>
      {postagens.map((postagem, index) => (
        <View key={index} style={styles.card}>
          <View style={styles.header}>
            <Icon name="person-circle-outline" size={24} color="#333" style={styles.userIcon} />
            <Text style={styles.nomeUsuario}>{postagem.nomeUsuario}</Text>
            <Text style={styles.dataHorario}>{postagem.data}</Text>
          </View>
          <Text style={styles.titulo}>{postagem.titulo}</Text>
          <Text style={styles.descricao}>{postagem.descricao}</Text>
          {postagem.imagem && <Image source={{ uri: postagem.imagem }} style={styles.imagem} />}
          <View style={styles.botaoContainer}>
            <TouchableOpacity
              style={[styles.botaoLike, interacaoUsuario[index] && styles.interacaoBloqueada]}
              onPress={() => handleInteracao(index, 'like')}
              disabled={interacaoUsuario[index]}
            >
              <Icon name="heart-outline" size={20} color="black" />
              <Text style={styles.botaoTexto}>{postagem.likes}</Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={[styles.botaoDeslike, interacaoUsuario[index] && styles.interacaoBloqueada]}
              onPress={() => handleInteracao(index, 'deslike')}
              disabled={interacaoUsuario[index]}
            >
              <Icon name="heart-dislike-outline" size={20} color="black" />
              <Text style={styles.botaoTexto}>{postagem.deslikes}</Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={styles.mostrarComentarios}
              onPress={() => toggleComentarios(index)}
            >
              <Icon name={mostrarComentarios[index] ? 'eye' : 'eye-off'} size={20} color="#77BECF" />
              <Text style={styles.mostrarComentariosTexto}>
                {mostrarComentarios[index] ? 'Ocultar Comentários' : 'Mostrar Comentários'}
              </Text>
            </TouchableOpacity>
          </View>
          {mostrarComentarios[index] && (
            <View style={styles.comentariosContainer}>
              {postagem.comentarios.map((comentario, i) => (
                <View key={i} style={styles.comentarios}>
                  <Text>{comentario.autor}: {comentario.texto}</Text>
                </View>
              ))}
              <View style={styles.botoesAdicionarComentarioContainer}>
                <TextInput
                  style={styles.inputComentario}
                  placeholder="Digite seu comentário..."
                  value={novoComentario}
                  onChangeText={setNovoComentario}
                />
                <TouchableOpacity
                  style={styles.botaoAdicionarComentario}
                  onPress={() => enviarComentario(index)}
                >
                  <Text style={styles.botaoAdicionarComentarioTexto}>Enviar</Text>
                </TouchableOpacity>
              </View>
            </View>
          )}
        </View>
      ))}
    </View>
  );
};

const styles = StyleSheet.create({
  card: {
    backgroundColor: '#fff',
    borderRadius: 12,
    padding: 16,
    marginBottom: 24,
    borderWidth: 1,
    borderColor: '#ddd',
  },
  header: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 8,
  },
  nomeUsuario: {
    fontSize: 16,
    fontWeight: 'bold',
    marginLeft: 8,
  },
  dataHorario: {
    color: '#666',
    marginLeft: 'auto',
  },
  titulo: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 8,
  },
  descricao: {
    marginBottom: 8,
  },
  imagem: {
    width: '100%',
    height: 200,
    borderRadius: 12,
    marginTop: 8,
  },
  botaoContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginTop: 8,
  },
  botaoLike: {
    flexDirection: 'row',
    alignItems: 'center',
    padding: 8,
    borderRadius: 4,
  },
  botaoDeslike: {
    flexDirection: 'row',
    alignItems: 'center',
    padding: 8,
    borderRadius: 4,
  },
  botaoTexto: {
    marginLeft: 4,
  },
  userIcon: {
    marginRight: 8,
  },
  interacaoBloqueada: {
    backgroundColor: 'transparent',
  },
  comentariosContainer: {
    marginTop: 8,
    borderTopWidth: 1,
    borderTopColor: '#ddd',
    paddingTop: 8,
  },
  comentarios: {
    marginTop: 8,
  },
  mostrarComentarios: {
    flexDirection: 'row',
    alignItems: 'center',
    color: 'blue',
    marginTop: 8,
  },
  mostrarComentariosTexto: {
    marginLeft: 4,
  },
  botoesAdicionarComentarioContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: 8,
  },
  inputComentario: {
    flex: 1,
    borderWidth: 1,
    borderColor: '#ddd',
    borderRadius: 4,
    padding: 8,
    marginRight: 8,
  },
  botaoAdicionarComentario: {
    backgroundColor: 'green',
    borderRadius: 4,
    paddingVertical: 8,
    paddingHorizontal: 16,
  },
  botaoAdicionarComentarioTexto: {
    color: '#fff',
  },
});

export default HomeScreen;
