# coffeman
REST API para gerenciar pessoas envolvidas na escala de fazer café ;-)

Entidades envolvidas
  Evento
	id
	descricao
	datavalidade
	
UsuarioEvento
	id
	descricao
	idEvento
	idUsuario
	
Agendamento
	id
	descricao
	idEvento
	DataAgendamento
	
AgendamentoUsuario
	id
	idAgendamento
	idUsuario
	HoraAgendamento
	Status
	
Usuario
	id
	nome
	email
	perfil
	ativo
