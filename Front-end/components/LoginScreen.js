import React from 'react';
import { View, Text, TextInput, TouchableOpacity } from 'react-native';
import { FontAwesome5 } from '@expo/vector-icons'; // Importe o ícone FontAwesome5

const LoginScreen = ({ navigation }) => {
  const handleLogin = () => {
    // Lógica de autenticação aqui
    // Navegar para a tela Home após o login
    navigation.navigate('Home');
  };

  const handleCadastro = () => {
    // Navegar para a tela de cadastro
    navigation.navigate('Cadastro');
  };

  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center', paddingTop: 50 }}>
      {/* Texto "Flora Sentinel" envolto por um componente Text */}
      <Text style={{ color: '#714D22', fontSize: 44, fontWeight: '700', letterSpacing: 1, marginBottom: 20 }}>Flora Sentinel</Text>

      {/* Box do email */}
      <View style={{ flexDirection: 'row', alignItems: 'center', width: 323, height: 46, backgroundColor: '#EAEBEC', borderRadius: 65, overflow: 'hidden', marginBottom: 15 }}>
        <FontAwesome5 name="envelope" size={16} color="#A9A9A9" style={{ marginLeft: 15, marginRight: 10 }} />
        <TextInput
          style={{ flex: 1, paddingLeft: 5, fontSize: 16 }} // Estilos para o input de texto
          placeholder="Email"
          keyboardType="email-address"
          autoCapitalize="none"
        />
      </View>

      {/* Box da senha */}
      <View style={{ flexDirection: 'row', alignItems: 'center', width: 323, height: 46, backgroundColor: '#EAEBEC', borderRadius: 65, overflow: 'hidden', marginBottom: 15 }}>
        <FontAwesome5 name="lock" size={16} color="#A9A9A9" style={{ marginLeft: 15, marginRight: 10 }} />
        <TextInput
          style={{ flex: 1, paddingLeft: 5, fontSize: 16 }} // Estilos para o input de texto
          placeholder="Senha"
          secureTextEntry={true}
        />
      </View>

      {/* Botão de Login */}
      <TouchableOpacity
        style={{ width: 200, height: 40, backgroundColor: '#77BECF', justifyContent: 'center', alignItems: 'center', borderRadius: 20, marginBottom: 20 }}
        onPress={handleLogin}
      >
        <Text style={{ color: '#fff', fontSize: 16 }}>Login</Text>
      </TouchableOpacity>

      {/* Texto de cadastro */}
      <Text style={{ color: '#024854', fontSize: 12, marginBottom: 10 }}>Ainda não possui conta?</Text>

      {/* Botão de Cadastro */}
      <TouchableOpacity
        style={{ width: 267, height: 39, backgroundColor: 'transparent', borderWidth: 1.5, borderColor: '#77BECF', justifyContent: 'center', alignItems: 'center', borderRadius: 65 }}
        onPress={handleCadastro}
      >
        <Text style={{ color: '#77BECF', fontSize: 16 }}>Cadastre-se</Text>
      </TouchableOpacity>
    </View>
  );
};

export default LoginScreen;
