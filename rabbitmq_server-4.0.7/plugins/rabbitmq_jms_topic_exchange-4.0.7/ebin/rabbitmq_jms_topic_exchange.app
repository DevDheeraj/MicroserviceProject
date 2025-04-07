{application, 'rabbitmq_jms_topic_exchange', [
	{description, "RabbitMQ JMS topic selector exchange plugin"},
	{vsn, "4.0.7"},
	{id, "834a101"},
	{modules, ['rabbit_db_jms_exchange','rabbit_db_jms_exchange_m2k_converter','rabbit_jms_topic_exchange','sjx_evaluator']},
	{registered, []},
	{applications, [kernel,stdlib,mnesia,rabbit_common,rabbit,khepri,khepri_mnesia_migration]},
	{optional_applications, []},
	{env, []}
]}.