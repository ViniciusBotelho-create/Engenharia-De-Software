import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert } from 'react-native';
import { FontAwesome5 } from '@expo/vector-icons'; // Importe o ícone FontAwesome5

const CadastroScreen = ({ navigation }) => {
  const [primeiroNome, setPrimeiroNome] = useState('');
  const [ultimoNome, setUltimoNome] = useState('');
  const [email, setEmail] = useState('');
  const [contato, setContato] = useState('');
  const [dataNascimento, setDataNascimento] = useState('');
  const [cep, setCep] = useState('');
  const [endereco, setEndereco] = useState('');
  const [numero, setNumero] = useState('');
  const [senha, setSenha] = useState('');
  const [confirmacaoSenha, setConfirmacaoSenha] = useState('');

  const handleCadastro = () => {
    if (senha !== confirmacaoSenha) {
      Alert.alert('Erro', 'A senha e a confirmação de senha não coincidem.');
      return;
    }

    // Lógica de cadastro aqui
    // Navegar para a tela Home após o cadastro
    navigation.navigate('Home');
  };

  const handleEntrar = () => {
    // Lógica para navegar para a tela de login
    navigation.navigate('Login');
  };

  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center', paddingHorizontal: 20 }}>
      <Text style={{ textAlign: 'center', color: '#293844', fontSize: 30, fontWeight: '600', lineHeight: 50, marginBottom: 20 }}>Cadastre-se</Text>

      <View style={{ width: '100%', marginBottom: 15 }}>
        {/* Primeiro nome */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="user" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Primeiro nome"
            value={primeiroNome}
            onChangeText={setPrimeiroNome}
          />
        </View>

        {/* Último nome */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="user" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Último nome"
            value={ultimoNome}
            onChangeText={setUltimoNome}
          />
        </View>

        {/* Email */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="envelope" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Email"
            value={email}
            onChangeText={setEmail}
            keyboardType="email-address"
            autoCapitalize="none"
          />
        </View>

        {/* Contato */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="phone" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Contato"
            value={contato}
            onChangeText={setContato}
            keyboardType="phone-pad"
          />
        </View>

        {/* Data de Nascimento */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="calendar-alt" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Data de Nascimento"
            value={dataNascimento}
            onChangeText={setDataNascimento}
            keyboardType="numeric"
          />
        </View>

        {/* CEP */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="map-marker-alt" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="CEP"
            value={cep}
            onChangeText={setCep}
            keyboardType="numeric"
          />
        </View>

        {/* Endereço */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="map-marked-alt" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Endereço"
            value={endereco}
            onChangeText={setEndereco}
          />
        </View>

        {/* Número */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="hashtag" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Número"
            value={numero}
            onChangeText={setNumero}
            keyboardType="numeric"
          />
        </View>

        {/* Nova senha */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="lock" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Nova senha"
            secureTextEntry={true}
            value={senha}
            onChangeText={setSenha}
          />
        </View>

        {/* Confirmação de senha */}
        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
          <FontAwesome5 name="lock" size={16} color="#A9A9A9" style={{ marginRight: 10 }} />
          <TextInput
            style={{ flex: 1, height: 46, paddingHorizontal: 20, fontSize: 16, backgroundColor: '#EAEBEC', borderRadius: 65, marginBottom: 15 }}
            placeholder="Confirmação de senha"
            secureTextEntry={true}
            value={confirmacaoSenha}
            onChangeText={setConfirmacaoSenha}
          />
        </View>
      </View>

      {/* Botão de cadastro */}
      <TouchableOpacity
        style={{ width: '100%', height: 50, backgroundColor: '#77BECF', justifyContent: 'center', alignItems: 'center', borderRadius: 65, marginBottom: 15 }}
        onPress={handleCadastro}
      >
        <Text style={{ color: '#fff', fontSize: 16 }}>Cadastrar</Text>
      </TouchableOpacity>

      {/* Texto "Já possui conta?" */}
      <Text style={{ textAlign: 'center', color: '#293844', fontSize: 16, marginBottom: 10 }}>Já possui conta?</Text>

      {/* Botão "Entrar" */}
      <TouchableOpacity
        style={{ width: 267, height: 39, borderRadius: 65, overflow: 'hidden', borderWidth: 1.5, borderColor: '#77BECF', justifyContent: 'center', alignItems: 'center' }}
        onPress={handleEntrar}
      >
        <Text style={{ textAlign: 'center', color: '#77BECF', fontSize: 16, fontFamily: 'sans-serif', fontWeight: '600', lineHeight: 39 }}>Entrar</Text>
      </TouchableOpacity>
    </View>
  );
};

export default CadastroScreen;
