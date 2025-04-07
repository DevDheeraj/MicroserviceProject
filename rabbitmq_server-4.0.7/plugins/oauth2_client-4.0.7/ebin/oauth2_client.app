{application, 'oauth2_client', [
	{description, "OAuth2 client from the RabbitMQ Project"},
	{vsn, "4.0.7"},
	{id, "834a101"},
	{modules, ['jwt_helper','oauth2_client']},
	{registered, []},
	{applications, [kernel,stdlib,ssl,inets,crypto,public_key,rabbit_common,jose]},
	{optional_applications, []},
	{env, []}
]}.